using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    



   [SerializeField] Rigidbody2D rb;
    public float moveSpeed = 20;
    
    Vector2 movement;

 void Start () {
         
     }
     

    // Update is called once per frame
    void Update()
    {
        //transformMovement();
        //velocityMovement();
        
        
            movement.x = Input.GetAxisRaw("Horizontal");   
            movement.y =  Input.GetAxisRaw("Vertical");
        
        

       
    }

    private void FixedUpdate() {

        //rb.MovePosition(rb.position + movement * moveSpeed * Time.deltaTime);
        rb.velocity = movement*moveSpeed;
    }

    void transformMovement()
    {
        if(Input.GetKey(KeyCode.A))
        {
            transform.position += (Vector3.left * moveSpeed * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.D))
        {
            transform.position += (Vector3.right * moveSpeed * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.W))
        {
            transform.position += (Vector3.up * moveSpeed * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.S))
        {
            transform.position += (Vector3.down * moveSpeed * Time.deltaTime);
        }
        
       
    }
    void velocityMovement()
    {
       Vector2 dir = Vector2.zero;
            if (Input.GetKey(KeyCode.A))
            {
                dir.x = -1;
                //animator.SetInteger("Direction", 3);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                dir.x = 1;
                //animator.SetInteger("Direction", 2);
            }

            if (Input.GetKey(KeyCode.W))
            {
                dir.y = 1;
                //animator.SetInteger("Direction", 1);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                dir.y = -1;
                //animator.SetInteger("Direction", 0);
            }

            dir.Normalize();
            //animator.SetBool("IsMoving", dir.magnitude > 0);

            GetComponent<Rigidbody2D>().velocity = moveSpeed * dir;
    }

    




    


}
