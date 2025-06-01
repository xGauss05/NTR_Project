using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static PauseMenu Singleton;

    [SerializeField] GameObject canvas;
    [SerializeField] GameObject player;

    public bool gamePaused = false;

    private void Awake()
    {
        if (Singleton != null && Singleton != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Singleton = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SetPauseState(!gamePaused);
        }
    }

    public void SetPauseState(bool paused)
    {
        canvas.SetActive(paused);

        gamePaused = paused;

        Cursor.lockState = paused ? CursorLockMode.None : CursorLockMode.Locked;
    }

    public void ExitToMenu()
    {
        SceneManager.LoadScene("0_MainMenu");
    }
}
