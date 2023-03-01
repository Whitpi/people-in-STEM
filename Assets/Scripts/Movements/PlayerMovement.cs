using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

   [SerializeField] Rigidbody2D rb;
    public float moveSpeed = 20;
    
    Vector2 movement;
     

    // Update is called once per frame
    void Update()
    {
            movement.x = Input.GetAxisRaw("Horizontal");   
            movement.y =  Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate() {

        //rb.MovePosition(rb.position + movement * moveSpeed * Time.deltaTime);
        rb.velocity = movement*moveSpeed;
    }

    


}
