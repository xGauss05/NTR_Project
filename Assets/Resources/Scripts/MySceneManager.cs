using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MySceneManager : MonoBehaviour
{
    private void Awake()
    {
        if (SceneManager.GetActiveScene().name == "1_Cinematic" ||
            SceneManager.GetActiveScene().name == "3_Escape" ||
            SceneManager.GetActiveScene().name == "4_BadEnding" ||
            SceneManager.GetActiveScene().name == "5_GoodEnding")
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }

    public void ChangeScene(string sceneName)
    {
        Transitioner.Singleton.FadeToBlack(sceneName);
    }
}
