using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 5f; // Düþmanýn hareket hýzý
    public float minY = 2f; // Düþmanýn hareket edebileceði minimum y konumu
    public float maxY = 8f; // Düþmanýn hareket edebileceði maksimum y konumu

    private Rigidbody2D rb;
    private bool movingUp = true; // Düþmanýn yukarý mý aþaðý mý hareket ettiðini belirleyen deðiþken

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
