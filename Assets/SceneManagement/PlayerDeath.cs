using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    [SerializeField] FPSController FPS;
    [SerializeField] CanvasGroup deathScreen;
    [SerializeField] CanvasGroup completionDeathScreen;
    private bool complete;
    private CompleteScript completeScript;
    public bool dead;
    private float fadeOutSpeed;
    
   
    void Start()
    {
        bool webGLBuild = true;
        if (webGLBuild)
        {
            fadeOutSpeed = 0.016f;
        }
        else
        {
            print("oops");
            fadeOutSpeed = 0.008f;
        }

        completeScript = GetComponent<CompleteScript>();
        dead = false;
    }

    // Update is called once per frame
    void Update()
    {
        complete = completeScript.complete;

        if (FPS.playerHealth < 1f && dead == false)
        {
            dead = true;
        }

        if (dead == true)
        {
            if (!complete) { deathScreen.interactable = true; deathScreen.blocksRaycasts = true; } else { completionDeathScreen.interactable = true; completionDeathScreen.blocksRaycasts = true; }
            FPS.lookSpeed = 0f;
            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;


            if (!complete)
            {
                if (deathScreen.alpha < 1f)
                {
                    deathScreen.alpha += fadeOutSpeed;
                }
            }
            else
            {
                if (completionDeathScreen.alpha < 1f)
                {
                    completionDeathScreen.alpha += fadeOutSpeed;
                }
            }

            if (AudioListener.volume > 0f)
            {
                AudioListener.volume -= fadeOutSpeed;
            }
        }
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        if (AudioListener.pause == true)
        {
            AudioListener.pause = false;
        }
        else
        {
            AudioListener.volume = 1f;
        }
        SceneManager.LoadScene("MainGameScene");
    }
}
