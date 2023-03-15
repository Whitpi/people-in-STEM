/// <summary>
/// Linijos kurejas
/// Yra prikabintas prie UI kameros
/// klauso peles inputu jei paspaudi objekta su tag "StringHole" issaugo kaip taska
/// Kai paspausti du taskai tarp ju nubrezia linija naudojant skripta "lineController"
/// </summary>
/// 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class linetest : MonoBehaviour
{
    Vector3[] points = new Vector3[2];
    [SerializeField] lineController line;
    int clicks = 0; //skaiciuojama paspaudimu skaicius

    [SerializeField] new Camera camera;

    // Update is called once per frame
    // Tinkamas klausyti paspaudimu ar kitu pasikeitimu nesusijusiu su fizika
    void Update()
    {
        //Laukia zaidejo pelytes paspaudimo ir ziuri ar nebuvo paspausta
        if (Input.GetMouseButtonDown(0) && clicks == 0)
        {
            //gauna ar paspaudimas atsitrenke i ka nors 
            RaycastHit2D hit = Physics2D.Raycast(camera.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            //Jei atsitrenke i ka nors ir tas kas nors turi tag "StringHole"
            if (hit.collider != null && hit.collider.CompareTag("StringHole"))
            {
                //issaugoma paspaudimo vieta
                points[0] = hit.transform.position;
                points[0].z = 1;
                clicks++;
            }

        }
        //atlieka viska ta pati kaip su pirmu ifu tiesiog isaugo kita taska sekancio paspaudimo metu
        //Be to issaukia metoda skripte "lineController" SetUpLine kuris ir sukuria linija
        else if (Input.GetMouseButtonDown(0) && clicks == 1)
        {
            RaycastHit2D hit = Physics2D.Raycast(camera.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null && hit.collider.CompareTag("StringHole"))
            {

                points[1] = hit.transform.position;
                points[1].z = 1;
                line.SetUpLine(points);
                clicks = 0;
            }
        }
    }
}
