using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] FPSController FPS;
    [SerializeField] GameObject pauseMenuUI;
    private float playerLookSpeed;
    private bool isPaused;

    private void Start()
    {
        playerLookSpeed = FPS.lookSpeed;
        isPaused = false;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
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
    
    private void Pause()
    {
        isPaused = true;

        FPS.lookSpeed = 0f;
        Time.timeScale = 0f;
        AudioListener.pause = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        pauseMenuUI.SetActive(true);
    }

    private void Resume()
    {
        isPaused = false;

        FPS.lookSpeed = playerLookSpeed;
        Time.timeScale = 1f;
        AudioListener.pause = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        pauseMenuUI.SetActive(false);
    }
}
