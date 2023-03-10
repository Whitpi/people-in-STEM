//using System.Threading.Tasks.Dataflow;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] Rigidbody2D rb;
    [SerializeField] float moveSpeed = 20;

    [SerializeField] LayerMask blockingLayer;

    Vector2 movement;
    //bool isMoving;
    BoxCollider2D boxCollider;

    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        //rb.MovePosition(rb.position + movement * moveSpeed * Time.deltaTime);

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
        }

    }

    // void AttemptMove(Vector2 direction)
    // {
    //     RaycastHit2D hit;
    //     if (Move(movement, out hit))
    //     {
    //         return;
    //     }
    //     BoxConundrum box = hit.transform.GetComponent<BoxConundrum>();
    //     OnBlocked(box, direction);

    // }
    // bool Move(Vector2 direction, out RaycastHit2D hit)
    // {
    //     Vector2 start = transform.position;
    //     Vector2 end = start + direction;

    //     boxCollider.enabled = false;
    //     hit = Physics2D.Linecast(start, end, blockingLayer);
    //     boxCollider.enabled = true;
    //     if (hit.transform == null)
    //     {

    //         return true;
    //     }
    //     return false;
    // }
    // void OnBlocked(BoxConundrum box, Vector2 direction)
    // {
    //     box.BoxPush(direction, blockingLayer);


    // }



}
