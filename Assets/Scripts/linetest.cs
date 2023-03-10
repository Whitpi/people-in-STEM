using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class linetest : MonoBehaviour
{
    Vector3[] points = new Vector3[2];
    [SerializeField] lineController line;
    int clicks = 0;

    [SerializeField] Camera camera;
    private void Start() {
        
        
    }
    void Update()
    {
        
        //Vector2 mousePos;

        if (Input.GetMouseButtonDown(0) && clicks == 0)
        {
            //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(camera.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            
            Debug.Log(hit.collider);
            if (hit.collider != null && hit.collider.CompareTag("StringHole")) {
            //hit.transform.position.z = 0;
            points[0] = hit.transform.position;
            points[0].z = 1;
            Debug.Log("Boom");
            clicks++;
            }

        }
        else if(Input.GetMouseButtonDown(0) && clicks == 1)
        {
            RaycastHit2D hit = Physics2D.Raycast(camera.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null && hit.collider.CompareTag("StringHole")) {
           
            points[1] = hit.transform.position;
            points[1].z = 1;
            line.SetUpLine(points);
            clicks=0;
            }
        }
    }
}
