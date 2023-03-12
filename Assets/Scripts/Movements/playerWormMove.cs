using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerWormMove : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float moveSpeed = 20;
    Vector2 movement;
    //bool isMoving;
    BoxCollider2D boxCollider;

    [SerializeField] GameObject greenBookUI;
    public bool greenBook;
    public bool redBook;

    [SerializeField] LayerMask blockingLayer;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
         if(other.gameObject.tag == "greenBook")
        {
            greenBook = true;
            other.gameObject.SetActive(false);
            greenBookUI.SetActive(true);
        }
        if(other.gameObject.tag == "redBook")
        {
            redBook = true;
            other.gameObject.SetActive(false);
        }

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        BoxConundrum box = other.transform.GetComponent<BoxConundrum>();

        RaycastHit2D hit;
        Vector2 start = transform.position;
        Vector2 end = start + movement;

        if (box != null)
        {
            
            boxCollider.enabled = false;
            hit = Physics2D.Linecast(start, end, blockingLayer);
            boxCollider.enabled = true;
           //Debug.Log(hit.transform.position);
            if (hit.transform != null)
                box.BoxPush(movement, blockingLayer);
        }
    }
    
    private void FixedUpdate()
    {
        if (movement.x != 0)
            movement.y = 0;
        if (movement.x != 0 || movement.y != 0)
        {
            //AttemptMove(movement);
            //rb.velocity = movement * moveSpeed;
            rb.MovePosition(rb.position + movement * moveSpeed * Time.deltaTime);
            rb.velocity = Vector2.zero;
        }

    }
}
