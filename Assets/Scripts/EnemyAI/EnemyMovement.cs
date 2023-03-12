using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float wormSpeed = 10;
    Vector2 movement;
    Transform transform;
    bool collided;
    bool isCurled;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        transform = GetComponent<Transform>();
        movement.y = 1;
        movement.x = 0;
    }

    // Update is called once per frame
    void Update()
    {


    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (!collided && !isCurled)
        {
            movement.y *= -1;

            Vector3 scale = transform.localScale;
            scale.y *= -1;
            transform.localScale = scale;

            collided = true;
        }
        if (other.gameObject.CompareTag("Player") && !isCurled)
        {
            playerWormMove script = other.gameObject.GetComponent<playerWormMove>();
            if (!script.greenBook && !script.redBook)
            {
                Destroy(other.gameObject);
            }
            else if (script.greenBook)
            {
                //Debug.Log("GreenDay");
            }
        }

    }
    private void FixedUpdate()
    {
        if(!isCurled)
            rb.MovePosition(rb.position + movement * wormSpeed * Time.deltaTime);
        if (collided) collided = false;
    }


    public void Curl()
    {
        Vector3 scale = transform.localScale;
        //Quaternion rotation = transform.rotation;
        scale.x += 1;
        //rotation.z = 90;
        rb.rotation = 90f;
        transform.localScale = scale;
        //transform.rotation = rotation;

        isCurled = true;
    }
}
