using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScreenChange : MonoBehaviour 
 {
    public void PlayPressed() 
    {
        SceneManager.LoadScene("SampleScene"); 
    } 
    public void ExitPressed()
    {
        Application.Quit(); 
        Debug.Log("Exit pressed!");
    } 
    public void MenuPressed() 
    {
        SceneManager.LoadScene("MainMenu");
    }
 }
 