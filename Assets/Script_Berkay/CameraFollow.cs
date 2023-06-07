using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float FollowSpeed = 2f;
    public float yOffset = 1f;
    public Transform target;

    public string destroyTag = "LevelEnd"; // Prefab'i yok etmek için kullanacağımız etiket

    private bool stopFollowing = false; // Karakterin takibini durdurma durumu

    private void LateUpdate()
    {
        if (!stopFollowing)
        {
            Vector3 newPosition = new Vector3(target.position.x, target.position.y + yOffset, -10);
            transform.position = Vector3.Slerp(transform.position, newPosition, FollowSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Eğer etiketiyle belirtilen prefab objesine çarpışma gerçekleştiyse takibi durdur
        if (collision.CompareTag(destroyTag))
        {
            stopFollowing = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        // Eğer etiketiyle belirtilen prefab objesine hala çarpıyorsak takibi devam ettir
        if (collision.CompareTag(destroyTag))
        {
            stopFollowing = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // Eğer etiketiyle belirtilen prefab objesinden ayrılıyorsak takibi yeniden başlat
        if (collision.CompareTag(destroyTag))
        {
            stopFollowing = false;
        }
    }
}