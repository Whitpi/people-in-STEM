using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class WormBehaviour : MonoBehaviour
{
    private bool move = false; //Prasidedant lygiui nepasukamas kirminas
    private bool collided = false; //tikrina ar dabar susidūrę
    private bool once = true;
    [SerializeField] private AudioSource movesoundeffect;

    private GameObject playerBookIcon;
    BookSpawn bookSpawnScript;

    Book heldBook = null;
    Animator wormAnimator;

    void Start()
    {
        wormAnimator = GetComponent<Animator>();
    }

    //Susidūrus objektams tikrina ar kitas obj turi vaikščiojimo scriptą ir ar yra užregistruota paimta knyga. Jei taip leidžia pasukti kirminą
    private void OnCollisionEnter2D(UnityEngine.Collision2D collision)
    {
        collided = true;

        if (collision.gameObject.TryGetComponent(out playerWormMove foundPWM))
        {
            heldBook = foundPWM.GetHeldBook();
            playerBookIcon = foundPWM.GetHeldBookIcon();
            bookSpawnScript = foundPWM.GetComponent<BookSpawn>();

            if (heldBook != null)
                move = true;
            else
                move = false;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        collided = false;
    }

    //Jei objektai susidurę, susidūrimo metu rasta knyga ir paspaudžiamas space, pasuką kirminą.
    private void Update()
    {
        if (collided && once && move && Input.GetKeyDown(KeyCode.Space))
        {
            movesoundeffect.Play();
           switch (heldBook.BookType)
            {
                case Book.BookTypes.Blue:
                    wormAnimator.SetTrigger("worm_tail_left");
                    if (playerBookIcon != null)
                        playerBookIcon.SetActive(false);
                    if (bookSpawnScript != null)
                        bookSpawnScript.RemoveBook();
                    break;

                case Book.BookTypes.Green:
                    wormAnimator.SetTrigger("worm_tail_right");
                    if (playerBookIcon != null)
                        playerBookIcon.SetActive(false);
                    if (bookSpawnScript != null)
                        bookSpawnScript.RemoveBook();
                    break;

                case Book.BookTypes.Yellow:
                    wormAnimator.SetTrigger("worm_tail_up");
                    if (playerBookIcon != null)
                        playerBookIcon.SetActive(false);
                    if (bookSpawnScript != null)
                        bookSpawnScript.RemoveBook();
                    break;
            }

        }
    }

}
