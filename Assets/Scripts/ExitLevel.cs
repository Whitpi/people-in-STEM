using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitLevel : MonoBehaviour
{
    
    public GameObject UIpanel;
    void OnTriggerEnter2D(Collider2D other)
    {
       // other.gameObject.GetComponent<SpriteRenderer>().sortingLayerName = sortingLayer;
        other.gameObject.SetActive(false);
        UIpanel.SetActive(true);
    }
}
