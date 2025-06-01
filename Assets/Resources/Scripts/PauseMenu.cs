using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject canvas;
    [SerializeField] GameObject player;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            SetPauseState(!canvas.activeInHierarchy);
        }
    }

    public void SetPauseState(bool paused)
    {
        canvas.SetActive(paused);

        player.GetComponent<PlayerMovement>().enabled = !paused;
        player.GetComponent<CameraController>().enabled = !paused;
        player.GetComponent<Interactor>().enabled = !paused;

        Cursor.lockState = paused ? CursorLockMode.None : CursorLockMode.Locked;
    }

    public void ExitToMenu()
    {
        SceneManager.LoadScene("0_MainMenu");
    }
}
