using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameCheckpoint : MonoBehaviour
{
    public Transform respawnPoint;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("DeathZone"))
        {
            GameObject ball = GameObject.FindGameObjectWithTag("Enemy");
            Debug.Log("hit");
            ball.transform.position = respawnPoint.position;
        }
    }
}