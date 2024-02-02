using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SCR_ui_elephants_screen : MonoBehaviour
{
    public GameObject elephantsScreen;
    public void LoadMenu()
    {
        Debug.Log("1");
        SceneManager.LoadScene("Scene_Main_menu");
    }
    public void QuitGame()
    {
        Debug.Log("Quitting");
        Application.Quit();
    }
}
