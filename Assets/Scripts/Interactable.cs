using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    [SerializeField]GameObject box;
    [SerializeField]GameObject firstPuzzle;
    
    void OnTriggerEnter2D(Collider2D other)
    {
        firstPuzzle.SetActive(true);
        box.SetActive(true);
        Debug.Log("Interact!!!");
        gameObject.SetActive(false);
    }
}
