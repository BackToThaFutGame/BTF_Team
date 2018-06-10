using System.Collections;
using System.Collections.Generic; 
using UnityEngine.SceneManagement;
using UnityEngine;

public class Character :MonoBehaviour{ 
    
    [SerializeField]
    private float speed = 3.0F; 
    [SerializeField]
    private float jumpforce = 3.0F;
    [SerializeField]
    private int lives = 3;
    private bool isGrounded = false;

    private Rigidbody2D PlayerRigidBody;
    private Animator animator;
    private SpriteRenderer Sprite; 

    private CharState State 
    {
        get { return (CharState)animator.GetInteger("State"); } 
        set { animator.SetInteger("State", (int)value); }
    }
     private void Awake()
    {
        PlayerRigidBody = GetComponentInChildren<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
        Sprite = GetComponentInChildren<SpriteRenderer>(); 

    } 
    private void Die() 
    {
        if(transform.position.y<-20) 
        {
            Application.LoadLevel(Application.loadedLevel); 

        } 
    }

    private void FixedUpdate()
    {
        CheckGround(); 

    }
    private void Move()
    { 
        Vector3 tempvector = Vector3.right * Input.GetAxis("Horizontal");
        transform.position = Vector3.MoveTowards(transform.position, transform.position + tempvector, speed * Time.deltaTime);


        if(tempvector.x<0)
        {
            Sprite.flipX = true;
        } 
        else 
        {
            Sprite.flipX = false;
        }
        State = CharState.Go;
    }
    private void Start()
    {
        
    } 

    public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Enemy")
            Application.LoadLevel(Application.loadedLevel);
    }

    private void CheckGround()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 0.3F);

        isGrounded = colliders.Length > 1;
      
    }
  
    private void Jump() 
    {
        State = CharState.Jump;
       PlayerRigidBody.AddForce(transform.up*jumpforce,ForceMode2D.Impulse);

    }


    private void Update()
    {
        State = CharState.Stay;
        if (Input.GetButton("Horizontal"))
        {
            Move();

        }


        if (isGrounded&&Input.GetButton("Jump"))
        {
            Jump();

        }

        Die();


    } 

    public enum CharState
    {
        Stay,
        Go,
        Jump

    }
}
