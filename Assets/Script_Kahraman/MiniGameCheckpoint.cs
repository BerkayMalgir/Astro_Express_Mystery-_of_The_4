using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameCheckpoint : MonoBehaviour
{
    

    public Transform respawnPoint; // Checkpoint'in respawn noktasý

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ball")) // Sadece "Ball" etiketine sahip objeleri kontrol etmek istiyorsanýz bu satýrý kullanabilirsiniz.
        {
            collision.transform.position = respawnPoint.position; // Karakterin pozisyonunu checkpoint'in respawn noktasýna taþý.
            // Ayrýca karakterin hýzýný sýfýrlamak veya baþka ayarlamalar yapmak isterseniz, burada yapabilirsiniz.
        }
    }
}

