using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float movementSpeed = 5f; // Top hareket hızı
    public int columnCount = 5; // Sütun sayısı
    public int rowCount = 3; // Satır sayısı
    public Transform spawnPoint; // Oluşturma noktası boş nesnesi

    private Transform[,] intersections; // Kesişim noktalarının dizisi
    private int currentRowIndex = 2; // Mevcut satırın indeksi
    private int currentColumnIndex = 0; // Mevcut sütunun indeksi
    private Vector3 targetPosition; // Geçiş için hedef pozisyon

    private bool isMoving = false; // Karakterin hareket edip etmediğini takip eden bayrak
    private Vector3 startPosition; // Hareketin başlangıç noktası
    private float movementStartTime; // Hareketin başlama zamanı
    private float movementDuration = 0.5f; // Hareket süresi (saniye)

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("DeathZone"))
        {
            ResetBallPosition();
        }
    }

    private void ResetBallPosition()
    {
        // Topun yeniden doğma konumu için mevcut satır ve sütun indekslerini ayarla
        currentRowIndex = 2;
        currentColumnIndex = 0;

        // Yeniden doğma indekslerine göre hedef pozisyonu hesapla
        targetPosition = intersections[currentRowIndex, currentColumnIndex].position;

        // Hareket değişkenlerini sıfırla
        isMoving = false;
        startPosition = targetPosition; // Başlangıç noktasını güncelle
        movementStartTime = Time.time; // Hareketin başlama zamanını güncelle
        transform.position = targetPosition;
    }

    private void Start()
    {
        intersections = new Transform[rowCount, columnCount]; // Kesişim noktalarının dizisini başlat

        // Her bir kesişim noktasının pozisyonunu hesapla
        float columnSpacing = 2f; // Sütunlar arası boşluk
        float rowSpacing = 2f; // Satırlar arası boşluk

        for (int row = 0; row < rowCount; row++)
        {
            for (int column = 0; column < columnCount; column++)
            {
                // Boşluk ve satır/sütun indeksine göre pozisyonu hesapla
                Vector3 position = spawnPoint.position + new Vector3(column * columnSpacing, row * rowSpacing, 0f);

                // Hesaplanan pozisyonda bir kesişim nesnesi oluştur
                GameObject intersectionObj = GameObject.CreatePrimitive(PrimitiveType.Cube);
                intersectionObj.transform.position = position;
                intersectionObj.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f); // Kesişim nesnelerinin boyutunu küçült

                // Kesişim nesnesini kesişimler dizisine atayın
                intersections[row, column] = intersectionObj.transform;
            }
        }

        targetPosition = intersections[currentRowIndex, currentColumnIndex].position; // İlk hedef pozisyonunu ayarla

        // Kesişim nesnelerinin görünürlüğünü kapat
        SetIntersectionVisibility(false);
    }

    private void Update()
    {
        // Her karede çağrılır

        // Karakterin zaten hareket edip etmediğini kontrol et
        if (isMoving)
        {
            // Hareketin başladığından beri geçen süreyi hesapla
            float elapsedTime = Time.time - movementStartTime;

            // Tamamlanan hareketin yüzdesini hesapla
            float percentageComplete = elapsedTime / movementDuration;

            // Lerp kullanarak hedef pozisyona doğru yumuşak bir şekilde hareket et
            transform.position = Vector3.Lerp(startPosition, targetPosition, percentageComplete);

            // Hareketin tamamlanıp tamamlanmadığını kontrol et
            if (percentageComplete >= 1f)
            {
                isMoving = false;
                transform.position = targetPosition; // Son pozisyonun doğru olduğundan emin ol
            }
        }
        else
        {
            // Girişleri kontrol et ve uygunsa yeni bir hareket başlat

            // A tuşuna basılıp basılmadığını kontrol et
            if (Input.GetKeyDown(KeyCode.A))
            {
                // Önceki sütuna geç (mümkünse)
                if (currentColumnIndex > 0)
                {
                    currentColumnIndex--;
                    StartMovementToIntersection(intersections[currentRowIndex, currentColumnIndex].position);
                }
            }
            // D tuşuna basılıp basılmadığını kontrol et
            else if (Input.GetKeyDown(KeyCode.D))
            {
                // Bir sonraki sütuna geç (mümkünse)
                if (currentColumnIndex < columnCount - 1)
                {
                    currentColumnIndex++;
                    StartMovementToIntersection(intersections[currentRowIndex, currentColumnIndex].position);
                }
            }
            // S tuşuna basılıp basılmadığını kontrol et
            else if (Input.GetKeyDown(KeyCode.S))
            {
                // Önceki satıra geç (mümkünse)
                if (currentRowIndex > 0)
                {
                    currentRowIndex--;
                    StartMovementToIntersection(intersections[currentRowIndex, currentColumnIndex].position);
                }
            }
            // W tuşuna basılıp basılmadığını kontrol et
            else if (Input.GetKeyDown(KeyCode.W))
            {
                // Bir sonraki satıra geç (mümkünse)
                if (currentRowIndex < rowCount - 1)
                {
                    currentRowIndex++;
                    StartMovementToIntersection(intersections[currentRowIndex, currentColumnIndex].position);
                }
            }
        }

        // V tuşuna basılıp basılmadığını kontrol et ve kesişimlerin görünürlüğünü değiştir
        if (Input.GetKeyDown(KeyCode.V))
        {
            bool isVisible = intersections[0, 0].gameObject.activeSelf;
            SetIntersectionVisibility(!isVisible);
        }
    }

    // Kesişim nesnelerinin görünürlüğünü ayarlayan fonksiyon
    private void SetIntersectionVisibility(bool isVisible)
    {
        foreach (Transform intersection in intersections)
        {
            intersection.gameObject.SetActive(isVisible);
        }
    }

    // Belirli bir pozisyona yeni bir hareketi başlatan fonksiyon
    private void StartMovementToIntersection(Vector3 destination)
    {
        // Başlangıç noktasını ve zamanını sakla
        startPosition = transform.position;
        movementStartTime = Time.time;

        // Hedef pozisyonu ayarla ve hareketi başlat
        targetPosition = destination;
        isMoving = true;
    }
}
