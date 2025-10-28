using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] FPSController FPS;
    [SerializeField] GameObject pauseMenuUI;
    [SerializeField] GameObject optionsMenuUI;
    [SerializeField] Slider mouseSensSlider;
    [SerializeField] TextMeshProUGUI mouseSensSliderVal;
    [SerializeField] VideoPlayer vidPlayer;
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
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            if (isPaused == false)
            {
                Pause();
            }
            else
            {
                Resume();   
            }
        }

        if (optionsMenuUI.activeSelf)
        {
            updateSlider();
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
        vidPlayer.Pause();

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
        vidPlayer.Play();

        pauseMenuUI.SetActive(false);
    }

    public void Menu()
    {
        SceneManager.LoadScene("StartMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Options()
    {
        pauseMenuUI.SetActive(false);
        optionsMenuUI.SetActive(true);
    }

    public void OptionsBack()
    {
        pauseMenuUI.SetActive(true);
        optionsMenuUI.SetActive(false);
    }
    
    public void updateSlider()
    {
        mouseSensSliderVal.text = (mouseSensSlider.value * 50).ToString("0");
        playerLookSpeed = mouseSensSlider.value;
    }
}


