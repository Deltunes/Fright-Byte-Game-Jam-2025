using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    [SerializeField] FPSController FPS;
    [SerializeField] CanvasGroup deathScreen;
    private bool dead;
    // Start is called before the first frame update
    void Start()
    {
        dead = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (FPS.playerHealth < 1f && dead == false)
        {
            dead = true;

            deathScreen.interactable = true;

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            FPS.lookSpeed = 0f;
            Time.timeScale = 0f;
        }

        if (dead == true)
        {
            if (deathScreen.alpha < 1f)
            {
                deathScreen.alpha += 0.008f;
            }

            if (AudioListener.volume > 0f)
            {
                AudioListener.volume -= 0.008f;
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
