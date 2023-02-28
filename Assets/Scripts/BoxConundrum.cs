using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxConundrum : MonoBehaviour
{
    public string sortingLayer;
    void OnTriggerEnter2D(Collider2D other)
    {
       // other.gameObject.GetComponent<SpriteRenderer>().sortingLayerName = sortingLayer;
        
    }
}
