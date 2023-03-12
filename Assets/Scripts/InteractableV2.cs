using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractableV2 : MonoBehaviour
{
    [SerializeField]bool isInRange;
    [SerializeField]KeyCode interactKey = KeyCode.E;
    [SerializeField]UnityEvent interactAction;
    bool once;

    // Update is called once per frame
    void Update()
    {
        if(isInRange && Input.GetKeyDown(interactKey) && !once)
        {
            interactAction.Invoke();
            once = false;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            isInRange = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            isInRange = false;
        }
    }
}
