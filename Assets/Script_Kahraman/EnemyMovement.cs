using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 5f; // D��man�n hareket h�z�
    public float minY = 2f; // D��man�n hareket edebilece�i minimum y konumu
    public float maxY = 8f; // D��man�n hareket edebilece�i maksimum y konumu

    private Rigidbody2D rb;
    private bool movingUp = true; // D��man�n yukar� m� a�a�� m� hareket etti�ini belirleyen de�i�ken

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
