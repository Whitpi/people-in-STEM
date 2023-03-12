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
       // other.gameObject.GetComponent<SpriteRenderer>().sortingLayerName = sortingLayer;
        other.gameObject.SetActive(false);
        exitUI.SetActive(true);
        MainCamera.SetActive(false);
        UIcamera.SetActive(true);
    }
}
