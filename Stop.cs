using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stop : MonoBehaviour {
    private bool paused = false;
    public GameObject panel;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKeyDown(KeyCode.Escape)) 
        {
           if (!paused) 
            {
                Time.timeScale = 0;
                paused = true;
                panel.SetActive(true); 
            } 
            else{
                Time.timeScale = 1;
                paused = false;
                panel.SetActive(false);
            }
        }
	}
}
 