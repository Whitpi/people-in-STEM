using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookSound : MonoBehaviour
{

    AudioSource source;


    // Start is called before the first frame update
    private void Start()
    {
        source = GetComponent<AudioSource>();
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       source.Play();
    }
}
