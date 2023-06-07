using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform target1; // İlk hedef noktası
    public Transform target2; // İkinci hedef noktası
    public float speed = 2f; // Hareket hızı

    private Transform currentTarget; // Şu anki hedef noktası

    private void Start()
    {
        // İlk hedef noktasını başlangıçta ayarla
        currentTarget = target1;
    }

    private void Update()
    {
        // Hedef noktaya doğru hareket et
        transform.position = Vector2.MoveTowards(transform.position, currentTarget.position, speed * Time.deltaTime);

        // Eğer şu anki hedefe ulaşıldıysa, hedefi değiştir
        if (Vector2.Distance(transform.position, currentTarget.position) < 0.1f)
        {
            if (currentTarget == target1)
                currentTarget = target2;
            else
                currentTarget = target1;
        }
    }
}