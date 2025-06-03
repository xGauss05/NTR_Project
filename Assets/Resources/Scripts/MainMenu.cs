using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void StartGame()
    {
        Transitioner.Singleton.FadeToBlack("1_Cinematic");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
