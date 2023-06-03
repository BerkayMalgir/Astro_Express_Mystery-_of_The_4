using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameCheckpoint : MonoBehaviour
{
    

    public Transform respawnPoint; // Checkpoint'in respawn noktas�

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ball")) // Sadece "Ball" etiketine sahip objeleri kontrol etmek istiyorsan�z bu sat�r� kullanabilirsiniz.
        {
            collision.transform.position = respawnPoint.position; // Karakterin pozisyonunu checkpoint'in respawn noktas�na ta��.
            // Ayr�ca karakterin h�z�n� s�f�rlamak veya ba�ka ayarlamalar yapmak isterseniz, burada yapabilirsiniz.
        }
    }
}

