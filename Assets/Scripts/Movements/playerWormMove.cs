using System.Net.Mime;
/// <summary>
/// Antrasis zaidejo judejimo skriptas(skirtas scenoje kirminas)
/// Pradzioje skyresi tuo kad neturejo stumdymo mechanikos bet ji dabar ir cia yra
/// Skirtumas nuo "PlayerMovement" yra knygos paemimo fiksavimas pagal tags daugiau viskas identiska
/// </summary>


using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.UI;

public class playerWormMove : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float moveSpeed = 20;
    Vector2 direction;

    BoxCollider2D boxCollider;
    SpriteRenderer playerSprite;
    [SerializeField] LayerMask blockingLayer;

    [SerializeField] GameObject bookIconUI;
    [SerializeField] GameObject equipedBook;
    [SerializeField] KeyCode pickupKey = KeyCode.F;
    [SerializeField] KeyCode dropKey = KeyCode.G;
    [SerializeField] LayerMask pickupLayer;

    [SerializeField] Sprite[] sprites = new Sprite[4];

    private bool start = true; //Stebi ar pasiektas pradžios taškas
    public Canvas infoScreen; //Galima prijungti canvas su informacija žaidėjui
    Scene currentScene;
    Vector3 startPosition;

    // Start is called before the first frame update
    //Pradzios darbai pasiemami objekto prie kurio prikabintas komponentai kad butu veliau lengviau
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        playerSprite = GetComponent<SpriteRenderer>();
        currentScene = SceneManager.GetActiveScene();
        startPosition = new Vector3(transform.position.x + 8, transform.position.y, 0);
    }

    // Update is called once per frame
    // Tinkamas klausyti paspaudimu ar kitu pasikeitimu nesusijusiu su fizika
    void Update()
    {
        //Kol pasiekiamas pradinis taškas vykdoma ėjimo funkcija
        if (start)
        {
            GameStart(ref start, startPosition);
        }

        direction.x = Input.GetAxisRaw("Horizontal");
        direction.y = Input.GetAxisRaw("Vertical");

        TikrintSprite(direction);

        //Jei paspaudžiamas h iškviečia instrukcijas
        if (Input.GetKeyDown(KeyCode.H) && !infoScreen.isActiveAndEnabled)
        {
            infoScreen.gameObject.SetActive(true);
            Time.timeScale = 0.0f;
        }

    }

    void TikrintSprite(Vector2 direction)
    {
        if (direction.x == 1)
        {
            /// i desine
            playerSprite.sprite = sprites[0];
        }
        if (direction.x == -1)
        {
            /// i kaire
            playerSprite.sprite = sprites[1];
        }
        if (direction.y == 1)
        {
            /// i virsu
            playerSprite.sprite = sprites[2];
        }
        if (direction.y == -1)
        {
            /// i apacia
            playerSprite.sprite = sprites[3];
        }

        if (Input.GetKeyDown(pickupKey))
        {
            TakeBook();
        }
        if (Input.GetKeyDown(dropKey))
        {
            DropBook();
        }
    }


    //Iskvieciamas kai objektas i kuri atsitrenke turi Coliider2D atributa (paprastai pasakius iskvieciamas kai atsirenkeme i ka nors)
    //Sioje situacijoje atliekame dezes stumima grid based style
    void OnCollisionEnter2D(Collision2D other)
    {
        BoxConundrum box = other.transform.GetComponent<BoxConundrum>(); // gaunama kito objekto pozicija jeigu tas objektas turi "BoxConundrum" skripta kitaip null

        //jei objektas deze(stumiamas objektas) atliekame
        if (box != null)
        {
            //Atliekamas kito objekto metodas "BoxPush" kur paduodama kryptis i kuria stumti ir "blockingLayer" lapas kuriame tikrins ar yra i ka galetu atsitrenkti
            box.BoxPush(direction, blockingLayer);
        }
    }


    // FixedUpdate yra naudojamas fizikai zaidime yra iskvieciamas pastoviai kol zaidimas veikia 
    //Judejimas per komponenta Rigidbody2D blokuojamas istrizas judejimas
    private void FixedUpdate()
    {
        if (direction.x != 0)
            direction.y = 0;
        if (direction.x != 0 || direction.y != 0)
        {
            //rb.position - dabartine vieta objekto
            //direction - kryptis i kuria judinsime objekta (turi x ir y, pvz x=1 ir y=0, tai judes i desine)
            //wormSpeed - greitis, kaip greitai nusigauna i norima taska
            //Time.deltaTime - laikrodis butinas judejimui kad nebutu nesamoniu 
            rb.MovePosition(rb.position + direction * moveSpeed * Time.deltaTime);//Naudojamas Unity metodas "MovePosition"  judinti zaidejui
            rb.velocity = Vector2.zero; //isjungiamas pagreitis kad nebutu nesamoniu (pastumiamas zaidejas judancio objekto igauna begalini pagreiti)
        }

    }


    bool once;


    public void TakeBook()
    {
        RaycastHit2D hit = Physics2D.CircleCast(transform.position, 1, Vector2.zero, 0, pickupLayer);

        BookSpawn bookSpawnScript = GetComponent<BookSpawn>();


        if (hit.transform != null)
        {
            
            Image bookIconImage = bookIconUI.GetComponent<Image>();

            if (bookSpawnScript.GetBookInfo() != null)
            {
                DropBook();
                //change book icon
                if (bookIconUI != null)
                    bookIconImage.sprite = bookSpawnScript.GetBookInfo().GameSprite;

            }

            GameObject bookToPickup = hit.collider.gameObject;
            Item book = bookToPickup.GetComponent<Item>();
            if (book != null)
            {
                once = false;


                bookSpawnScript.SetBook(book.GetBook());

                if (bookIconUI != null)
                {
                    bookIconImage.sprite = bookSpawnScript.GetBookInfo().GameSprite;
                    bookIconUI.SetActive(true);
                }

                Destroy(bookToPickup);
            }
        }
    }


    public void DropBook()
    {
        BookSpawn bookSpawnScript = GetComponent<BookSpawn>();
        if (bookSpawnScript.bookToSpawn != null && !once)
        {
            
            if (bookIconUI != null)
                bookIconUI.SetActive(false);

            bookSpawnScript.RemoveBook();

            Instantiate(bookSpawnScript.GetBookPrefab(), transform.position, Quaternion.identity);
            once = true;
        }
    }

    public Book GetHeldBook()
    {
        BookSpawn bookSpawnScript = GetComponent<BookSpawn>();
        if (bookSpawnScript.bookToSpawn != null)
            return bookSpawnScript.GetBookInfo();
        return null;
    }

    public GameObject GetHeldBookIcon()
    {
        //BookSpawn bookSpawnScript = GetComponent<BookSpawn>();
        if (bookIconUI != null)
            return bookIconUI;
        return null;
    }

    //Funkcija lygiui prasidedant 
    private void GameStart(ref bool start, Vector3 statPosition)
    {
        playerSprite.sprite = sprites[0];
        transform.position = Vector3.MoveTowards(transform.position, startPosition, 0.1f); //Pėlytės ejimas (esmas pozicija, galinė poz, greitis)
        //Kol nepasiekiama pozicija žaidimas starto būsenoje.
        if (transform.position == startPosition)
        {
            //Jei yra canvas su informacija žaidėjui, žaidimas sustabdomas rodomas langas.
            if (currentScene.name == "lvl1")
            {
                infoScreen.gameObject.SetActive(true);
                Time.timeScale = 0.0f;
            }
            start = false;
        }

    }

    //Funkcija pardėti žaidimą išjungiant info langą
    public void Resume()
    {
        Time.timeScale = 1.0f;
        infoScreen.gameObject.SetActive(false);
    }
}
