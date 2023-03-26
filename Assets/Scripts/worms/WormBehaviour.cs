using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class WormBehaviour : MonoBehaviour
{
    private bool rotate = false; //Prasidedant lygiui nepasukamas kirminas
    private bool collided = false; //tikrina ar dabar susidūrę
    private bool once = true;

    void Start()
    {
      
    }

    //Susidūrus objektams tikrina ar kitas obj turi vaikščiojimo scriptą ir ar yra užregistruota paimta knyga. Jei taip leidžia pasukti kirminą
    private void OnCollisionEnter2D(UnityEngine.Collision2D collision)
    {
        Book heldBook = null;
        collided = true;

        if (collision.gameObject.TryGetComponent(out playerWormMove foundPWM))
        {
            heldBook = foundPWM.GetHeldBook();
            if (heldBook != null)
                rotate = true;
            else
                rotate = false; 
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        collided = false;
    }

    //Jei objektai susidurę, susidūrimo metu rasta knyga ir paspaudžiamas space, pasuką kirminą.
    private void Update()
    {
       if (collided && once && rotate && Input.GetKeyDown(KeyCode.Space))
       {
          WormRotate();
          once = false;
       }
    }

   public void WormRotate()
   {
        Quaternion rot = Quaternion.Euler(0, 0, 90);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rot, 90);
        transform.position = transform.position + Vector3.down * 4; 
   }
    
}
