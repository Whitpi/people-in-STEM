/// <summary>
/// Panasus i skripta "Interactable" (reiketu sumerginti veliau)
/// Isejimo is lygio paprastas interactionas
/// Isjungia pagrindine kamera kuri rodo lygi
/// Ijungia UI kameara kuri rodo UI elementus ir ijungia sukurta isejimo zinutes UI
/// </summary>


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitLevel : MonoBehaviour
{
    
    [SerializeField] GameObject UIcamera;
    [SerializeField]GameObject exitUI;
    [SerializeField]GameObject MainCamera;
    
    void OnTriggerEnter2D(Collider2D other)
    {
        other.gameObject.SetActive(false); // isjungia zaideja
        exitUI.SetActive(true);//ijungia sukurta isejimo zinutes UI
        MainCamera.SetActive(false);// Isjungia pagrindine kamera kuri rodo lygi
        UIcamera.SetActive(true);// Ijungia UI kameara kuri rodo UI elementus
    }
}
