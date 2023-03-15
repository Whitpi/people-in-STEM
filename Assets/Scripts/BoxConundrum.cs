/// <summary>
/// Dezes judejimo skriptas
/// Zaidejui atsitrenkus i deze ir aktyvavus metoda "BoxPush"
/// Deze patikrina ar priekyje nera sienos ir juda grid style movementu
/// </summary>

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxConundrum : MonoBehaviour
{
    BoxCollider2D boxCollider;
    Rigidbody2D rb;
    
    bool isMoving;

    ///Parametrai grazesniam dezes stumimui nzn ar veikia pamirsau
    //float timeToMove = 0.2f;
    //public float moveTime = 0.1f;
    //float inverseMoveTime;

    //Pradzios darbai pasiemami objekto prie kurio prikabintas komponentai kad butu veliau lengviau
    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();

        //inverseMoveTime = 1f / moveTime; //parametras grazesniam judejimui
    }

    /// <summary>
    /// Objekto judejimo metodas grid based
    /// </summary>
    /// <param name="direction">kryptis i kuria judes</param>
    /// <param name="blockingLayer">layer kuria patikrinti ar nera sienu</param>
    public void BoxPush(Vector2 direction, LayerMask blockingLayer)
    {
        
        Vector2 start = Vector2.zero;
        Vector2 end = Vector2.zero;

        //Nusistatome tikrinimo ar yra siena taskus priklausant nuo krypties is kurios zaidejas stumia deze
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

        //Isjungiame dezes komponenta "BoxCollider2D" kad i save neatsitrenktu metodas Physycs2D.Linecast
        boxCollider.enabled = false;
        // Physycs2D.Linecast sauna tarp nustatytu tasku linija ir tikrina ar yra kas ja blokuoja (ar yra kokiu sienu)
        RaycastHit2D hit = Physics2D.Linecast(start, end, blockingLayer); //isaugome ar atsitrenkeme i ka nors i hit variable
        boxCollider.enabled = true;

        //jei neradome blokuojanciu objektu pajudiname deze(ar kitka prie ko prikabintas skriptas) per 1
        if (hit.transform == null && !isMoving)
        {
            transform.position += (Vector3)direction; //prie esamos objekto pozicijos pridedame 1 unita i kuria stumia zaidejas puse taip pakeisdami objekto pozicija
            
            //StartCoroutine(NotSmoothMovement(start + direction)); //grazesnis judejimas neveikia
        }
    }

    ///Grazesnis judejimas pastumimo kad nepersoktu i pozicija pastumtas bet letai perjudetu man atrodo neveike neatsimenu
    /// // private IEnumerator NotSmoothMovement(Vector3 end)
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
