using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtonFunctions : MonoBehaviour
{
    private GameObject pauseMenu;

    public void StartGame()
    {
        SceneManager.LoadScene("lvl1");
    }

    public void Exit()
    {
        Application.Quit();
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
