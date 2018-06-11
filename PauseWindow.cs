using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseWindow : MonoBehaviour {

    public void StartGamePressed()
    {
        SceneManager.LoadScene("SampleScene");
    } 
    public void MenuPressed() 
    {
        SceneManager.LoadScene("MainMenu");
    }
}
