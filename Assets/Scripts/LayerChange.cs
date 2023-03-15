/// <summary>
/// Turbut nereikalingas skriptas pritaikytas "level1 scenai"
/// Apibendrintai skirtas praejimui i antra auksta tik tada kai yra uzstumta deze i specifine vieta
/// Praejimas i antra auksta yra uzblokuotas nematomomis sienomis kurias sis skriptas isjungia kurios yra "collyders" rinkinyje
/// </summary>


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerChange : MonoBehaviour
{
    [SerializeField]string layer;
    [SerializeField]string sortingLayer;
    [SerializeField]GameObject[] colliders;
    [SerializeField]GameObject boxCheck;
    [SerializeField]GameObject disabledByCheck;
    [SerializeField]bool changeLayer;

    //Iskvieciamas kai objektas i kuri atsitrenke turi Coliider2D atributa kuriame nustatyta "isTrigger = true"
    //Siame atveji kai iseina is zonos
    private void OnTriggerExit2D(Collider2D other)
    {
        //jei pasirenkama kad bus keiciamas layer pachekinant "changeLayer"
        if(changeLayer == true)
        {
            other.gameObject.layer = LayerMask.NameToLayer(layer);
            other.gameObject.GetComponent<SpriteRenderer>().sortingLayerName = sortingLayer;
        }
        
        //Visi colliders rinkinyje esantys objektai paverciami i isTriggerr kad butu praeinami bet nedinktu is scenos
        foreach (GameObject collider in colliders) 
        {
            bool isTrigger = collider.GetComponent<Collider2D>().isTrigger;
            if(isTrigger == false) collider.GetComponent<Collider2D>().isTrigger = true;
            else collider.GetComponent<Collider2D>().isTrigger = false;
        }

    }

    //Iskvieciamas kai objektas i kuri atsitrenke turi Coliider2D atributa kuriame nustatyta "isTrigger = true"
    void OnTriggerStay2D(Collider2D other)
    {
        
        //Tikrinama ar objektas yra boxCheck
        if(other.gameObject == boxCheck)
        {
            disabledByCheck.SetActive(false); // isjungiamas objektas nustatytas disabledByCheck
        }
    }
}
