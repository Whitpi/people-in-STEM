
/// <summary>
/// Panasus i skripta "ExitLevel" (reiketu sumerginti veliau)
/// "First puzzle" UI ekranas
/// Ijungia deze stumimui pirmam lygi
/// Isjungia pagrindine kamera kuri rodo lygi
/// Ijungia UI kameara kuri rodo UI elementus ir ijungia sukurta first puzzle UI
/// </summary>


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    [SerializeField] GameObject box;
    [SerializeField] GameObject firstPuzzle;
    [SerializeField] GameObject UIcamera;
    [SerializeField] GameObject MainCamera;


    void OnTriggerEnter2D(Collider2D other)
    {

        firstPuzzle.SetActive(true); // ijungia sukurta first puzzle UI
        box.SetActive(true);// Ijungia deze stumimui pirmam lygi
        gameObject.SetActive(false); //paslepia first puzzle objekta
        MainCamera.SetActive(false);// Isjungia pagrindine kamera kuri rodo lygi
        UIcamera.SetActive(true);// Ijungia UI kameara kuri rodo UI elementus



    }
}
