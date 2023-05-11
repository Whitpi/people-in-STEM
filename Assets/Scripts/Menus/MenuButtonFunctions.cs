using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtonFunctions : MonoBehaviour
{
    private GameObject pauseMenu;
    [SerializeField] private AudioSource selectoundeffect;

    public void StartGame()
    {
        selectoundeffect.Play();
        SceneManager.LoadScene("lvl1");

    }

    public void Exit()
    {
        selectoundeffect.Play();
        Application.Quit();

    }

    public void AboutScreen()
    {
        selectoundeffect.Play();
        SceneManager.LoadScene("About");

    }

    public void BackToMainMenu()
    {
        selectoundeffect.Play();
        SceneManager.LoadScene("MainMenu");

    }

    public void Continue()
    {
        selectoundeffect.Play();
        Time.timeScale = 1.0f;
        pauseMenu.SetActive(false);
    }
}
