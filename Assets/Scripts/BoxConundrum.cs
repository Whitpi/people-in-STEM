using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxConundrum : MonoBehaviour
{
    BoxCollider2D boxCollider;
    Rigidbody2D rb;
    //float timeToMove = 0.2f;
    bool isMoving;
    //public float moveTime = 0.1f;
    //float inverseMoveTime;


    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        //inverseMoveTime = 1f / moveTime;
    }

    public void BoxPush(Vector2 direction, LayerMask blockingLayer)
    {
        Vector2 start = Vector2.zero;
        Vector2 end = Vector2.zero;
        if (direction.x != 0)
        {
            start = transform.position;
            end = start + direction;
            end.x += transform.localScale.x / 2 * direction.x;
        }


        if (direction.y != 0)
        {
            start = transform.position;
            end = start + direction;
            end.y += transform.localScale.y * direction.y;
        }

        boxCollider.enabled = false;
        RaycastHit2D hit = Physics2D.Linecast(start, end, blockingLayer);
        boxCollider.enabled = true;

        //Debug.Log(hit.transform.position);

        if (hit.transform == null && !isMoving)
        {
            //rb.AddForce(direction * 2, ForceMode2D.Impulse);
            transform.position += (Vector3)direction;
            //transform.position = Vector3.Lerp(start, end, 0.5f);
            //transform.Translate(direction * Time.deltaTime);
            //StartCoroutine(NotSmoothMovement(start + direction));
            //isMoving = false;
        }
    }

    // private IEnumerator NotSmoothMovement(Vector3 end)
    // {
    //     //The object is now moving.
    //     isMoving = true;

    //     //Calculate the remaining distance to move based on the sqr magnitude difference of current position and end 
    //     float sqrRemainingDistance = (transform.position - end).sqrMagnitude;

    //     //while distance is more than almost zero number
    //     while (sqrRemainingDistance > float.Epsilon)
    //     {
    //         //find position to move based on moveTime(a certain precentage of all the needed to move vector)
    //         Vector3 newPosition = Vector3.MoveTowards(rb.position, end, inverseMoveTime * Time.deltaTime);
    //         //Move the object through rigidbody 
    //         rb.MovePosition(newPosition);
    //         //recalculate the remaining distance
    //         sqrRemainingDistance = (transform.position - end).sqrMagnitude;
    //         yield return null;
    //     }

    //     //The object is no longer moving.
    //     isMoving = false;
    // }


}
