/// <summary>
/// Interactionu valdymo skriptas
/// Nustatcius nustatymus kai zaidejas ieina i veikimo zona ir paspaudzia mygtuka(default "e")
/// paleidziamas norimas pasirenkamas veiksmas
/// 
/// "isInRange" - tikrinimas ar zaidejas yra zonoje
/// "interactKey" - pasirenkamas veiksmo interaction mygtukas
/// "interactAction" - pasirenkami veiksmai kurie bus atlikti paspaudus mygtuka (gali buti belekiek)
/// </summary>

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
    //Tinkamas klausyti paspaudimu ar kitu pasikeitimu nesusijusiu su fizika
    void Update()
    {
        //Tikrinama ar yra zonoje ir paspaustas mygtukas ir ar nebuvo jau interaktinta
        if(isInRange && Input.GetKeyDown(interactKey) && !once)
        {
            interactAction.Invoke();//paleidzia nustatytus veiksmus
            once = false;// padaro kad butu viena karta
        }
    }

    //Iskvieciamas kai objektas i kuri atsitrenke turi Coliider2D atributa kuriame nustatyta "isTrigger = true"
    //Siame atveji kai patenka i zona
    void OnTriggerEnter2D(Collider2D other)
    {
        //jei zaidejas patenka i zona issaugome
        if(other.CompareTag("Player"))
        {
            isInRange = true;
        }
    }

    //Iskvieciamas kai objektas i kuri atsitrenke turi Coliider2D atributa kuriame nustatyta "isTrigger = true"
    //Siame atveji kai iseina is zonos
    void OnTriggerExit2D(Collider2D other)
    {
        //jei zaidejas iseina is zonos issaugome
        if(other.CompareTag("Player"))
        {
            isInRange = false;
        }
    }
}
