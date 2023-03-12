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

    private void OnTriggerExit2D(Collider2D other)
    {
        if(changeLayer == true)
        {
            //Debug.Log("Hit change");
            other.gameObject.layer = LayerMask.NameToLayer(layer);
            other.gameObject.GetComponent<SpriteRenderer>().sortingLayerName = sortingLayer;
        }
        

        //LayerMask layerMask = LayerMask.GetMask("YourLayerName");
        
        //Collider2D[] colliders = Physics2D.OverlapAreaAll(new Vector2(-1000f, -1000f), new Vector2(1000f, 1000f), layerMask);
        foreach (GameObject collider in colliders) // disabel when not needed
        {
            bool isTrigger = collider.GetComponent<Collider2D>().isTrigger;
            if(isTrigger == false) collider.GetComponent<Collider2D>().isTrigger = true;
            else collider.GetComponent<Collider2D>().isTrigger = false;
        }

    }
    void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject == boxCheck)
        {
            disabledByCheck.SetActive(false);
        }
    }
}
