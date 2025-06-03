using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Transitioner : MonoBehaviour
{
    public static Transitioner Singleton { get; private set; }

    [SerializeField] Image blackCurtain;
    [SerializeField] float speed = 1.0f;

    float myAlpha = 0.0f;
    bool transitioning = false;
    bool toBlack = true;
    string sceneToLoad;

    public void FadeToBlack(string targetScene)
    {
        transitioning = true;
        sceneToLoad = targetScene;
    }

    private void Awake()
    {
        #region Singleton

        if (Singleton != null && Singleton != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Singleton = this;
        }
        DontDestroyOnLoad(this.gameObject);

        #endregion Singleton
    }

    private void Update()
    {
        if (!transitioning) return;

        if (toBlack)
        {
            myAlpha += Time.deltaTime * speed;
        }
        else
        {
            myAlpha -= Time.deltaTime * speed;
        }
        blackCurtain.color = Color.Lerp(Color.clear, Color.black, myAlpha);


        if (myAlpha <= 0.0f)
        {
            toBlack = true;
            transitioning = false;
        }
        if (myAlpha >= 1.0f)
        {
            toBlack = false;

            //Do behaviour
            SceneManager.LoadScene(sceneToLoad);
        }
    }

}
