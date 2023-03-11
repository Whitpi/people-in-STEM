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

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (paused == true)
            {
                
                pauseMenu.gameObject.SetActive(false);
                UnityEngine.Cursor.visible = false;
                paused = false;
            }
            else
            {

                pauseMenu.gameObject.SetActive(true);
                UnityEngine.Cursor.visible = true;
                paused = true;
            }
        }
    }
    public void Resume()
    {
        pauseMenu.gameObject.SetActive(false);
        UnityEngine.Cursor.visible = false;
        paused = false;
    }
}
