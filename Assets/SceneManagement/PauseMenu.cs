using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] FPSController FPS;
    [SerializeField] GameObject pauseMenuUI;
    public float playerLookSpeed;
    public bool isPaused;

    private void Start()
    {
        playerLookSpeed = FPS.lookSpeed;

        FPS.lookSpeed = playerLookSpeed;
        Time.timeScale = 1f;
        AudioListener.pause = false;
        
        isPaused = false;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused == false)
            {
                Pause();
            }
            else
            {
                Resume();   
            }
            //Application.Quit();
        }
    }
    
    public void Pause()
    {
        isPaused = true;

        FPS.lookSpeed = 0f;
        Time.timeScale = 0f;
        AudioListener.pause = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        pauseMenuUI.SetActive(true);
    }

    public void Resume()
    {
        isPaused = false;

        FPS.lookSpeed = playerLookSpeed;
        Time.timeScale = 1f;
        AudioListener.pause = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        pauseMenuUI.SetActive(false);
    }

    public void Menu()
    {
        SceneManager.LoadScene("StartMenu");
    }
}


