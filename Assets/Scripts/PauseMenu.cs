using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    bool paused = false;

    void Start()
    {
        pauseMenu.gameObject.SetActive(false);
    }

    //when escape key is pressed pause menu pops up/disappears
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (paused == true)
            {
                Time.timeScale = 1.0f;
                pauseMenu.gameObject.SetActive(false);
                paused = false;
            }
            else
            {
                Time.timeScale = 0.0f;
                pauseMenu.gameObject.SetActive(true);
                paused = true;
            }
        }
    }

    public void Resume()
    {
        Time.timeScale = 1.0f;
        pauseMenu.gameObject.SetActive(false);
        paused = false;
    }
}
