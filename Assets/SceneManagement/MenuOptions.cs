using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuOptions : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("MainGameScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
