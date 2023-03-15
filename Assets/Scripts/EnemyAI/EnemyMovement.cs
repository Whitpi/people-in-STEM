/// <summary>
/// Skriptas kirmino judejimui
/// Kirminas juda aukstyn zemyn
/// Atsitrenkus i siena pakeicia y krypti (jei judejo aukstyn atsitrenkia i siena ir juda zemyn)
/// 
/// Sekanti funkcija atsitrenkus zaidejui i kirmina sunaikina 
/// Nesunaikina zaidejo jei turi zalia arba raudona knyga
/// 
/// Trecia funkcija metodas Curl()
/// Sustabdo judejima parotaitina 90 laipsniu ir padidina objekta
/// </summary>




using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float wormSpeed = 10;
    Vector2 direction;
    Transform transform;
    bool collided;
    bool isCurled;

    // Start is called before the first frame update
    //Pradzios darbai pasiemami objekto prie kurio prikabintas komponentai kad butu veliau lengviau
    //Be to priskiriama pradine judejimo kryptis
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        transform = GetComponent<Transform>();
        direction.y = 1;
        direction.x = 0;
    }

    /// <summary>
    /// Veiksmai atsitrenkus i objekta 
    /// </summary>
    /// <param name="other"></param>
    void OnCollisionEnter2D(Collision2D other)
    {
        //Kai kirminas atsitrenkia i siena jis apsisuka ir juda atgal
        if (!collided && !isCurled)
        {
            direction.y *= -1; // pakeiciama kryptis y asimi i priesinga nei buvo pries tai

            //Atliekami per daug sudetingi sprite apsukimo darbai pakeiciant dydi objekto i priesinga nei buvo pries tai y asimi 
            Vector3 scale = transform.localScale;
            scale.y *= -1;
            transform.localScale = scale;

            collided = true;
        }

        //Funkcionalumas atsitrenkus i kirmina kol kas jei neturi zaidejas knygos(zalios arba raudonos) zaidejas sunaikinamas
        if (other.gameObject.CompareTag("Player") && !isCurled)
        {
            playerWormMove script = other.gameObject.GetComponent<playerWormMove>();
            if (!script.greenBook && !script.redBook)
            {
                Destroy(other.gameObject);
            }
            else if (script.greenBook)
            {
                //Debug.Log("GreenDay");
            }
        }

    }

    // FixedUpdate yra naudojamas fizikai zaidime yra iskvieciamas pastoviai kol zaidimas veikia 
    //Judejimas per komponenta Rigidbody2D jei nera susirietes kirminas
    //Taip pat tikrinama ar atsitrenke i siena (naudojama apsisiukimui)
    private void FixedUpdate()
    {
        if(!isCurled)
        //rb.position - dabartine vieta objekto
        //direction - kryptis i kuria judinsime objekta (turi x ir y, pvz x=1 ir y=0, tai judes i desine)
        //wormSpeed - greitis, kaip greitai nusigauna i norima taska
        //Time.deltaTime - laikrodis butinas judejimui kad nebutu nesamoniu 
            rb.MovePosition(rb.position + direction * wormSpeed * Time.deltaTime); //Naudojamas Unity metodas "MovePosition"  judinti kirminui

        if (collided) collided = false;
    }

    //Metodas susiriesti
    //Sustabdo judejima parotaitina 90 laipsniu ir padidina objekta
    public void Curl()
    {
        //padidina objekta +1 didesniu nei buvo
        Vector3 scale = transform.localScale;
        scale.x += 1;
        transform.localScale = scale;

        //pasukame objekta 90 laipsniu
        rb.rotation = 90f;
        
        //issaugome kad susiriete tai nebegali judeti
        isCurled = true;
    }
}
