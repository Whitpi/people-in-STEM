using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtonFunctions : MonoBehaviour
{
    private GameObject pauseMenu;

    public void StartGame()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("level1");
    }

    public void Exit()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void AboutScreen()
    {
        SceneManager.LoadScene("About");
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Continue()
    {
        Time.timeScale = 1.0f;
        pauseMenu.SetActive(false);
    }
}
