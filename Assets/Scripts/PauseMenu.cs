﻿using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    //Nekabinti ant PauseMenu objekto, kadangi starte nurodomas kaip neactive, ir vėliau nesiaktivuoja

    public GameObject pauseMenu; // canvas su pauzės meniu
    bool paused = false; // stebi ar dabartinė situacija sustabdyta ar ne

    void Start()
    {
        pauseMenu.gameObject.SetActive(false);
    }

    //Paspaudus Esc įjungia/išjungia pauzės meniu
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (paused == true)
            {
                Time.timeScale = 1.0f;//pratęsiant laiko eiga galima toliau žaisti
                pauseMenu.gameObject.SetActive(false);
                paused = false;
            }
            else
            {
                Time.timeScale = 0.0f;//sustabdant laiką sustabdomas ir žaidėjo judėjimas
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
