using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickMovement : MonoBehaviour
{
    [SerializeField]float speed = 10f;
    Vector2 lastClickedPos;
    bool moving;
    [SerializeField] Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            lastClickedPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            moving = true;
        }
        

    }


    private void FixedUpdate() {

    ///May occasionally spin out
       if(moving && (Vector2)transform.position != lastClickedPos){

            //Moves Towards Cursor
            /* float step = speed * Time.deltaTime;
            rb.MovePosition(Vector2.MoveTowards(transform.position, lastClickedPos, step)); */
            //rb.MovePosition(rb.position + ((Vector2)transform.up * step));
            transform.position = lastClickedPos;
            //Rotates towards cursor
            Vector2 dir = lastClickedPos -(Vector2)transform.position;
            float angle = Vector2.SignedAngle(Vector2.up, dir);
            transform.eulerAngles = new Vector3 (0,0,angle); 
            
            
        }
        else{
            moving = false;
        }
    }
}
