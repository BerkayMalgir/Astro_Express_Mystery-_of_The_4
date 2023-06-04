using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 5f; 
    public float minY = 2f; 
    public float maxY = 8f; 

    private Rigidbody2D rb;
    private bool movingUp = true; 

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (movingUp)
        {
            rb.velocity = new Vector2(rb.velocity.x, speed);
            if (transform.position.y >= maxY)
            {
                movingUp = false;
            }
        }
        else
        {
            rb.velocity = new Vector2(rb.velocity.x, -speed);
            if (transform.position.y <= minY)
            {
                movingUp = true;
            }
        }
    }      
    }
