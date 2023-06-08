using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public string targetTriggerName;
    private bool _playerInRange;
    private bool _ballInRange;
    [Header("Visual Cue")]
    [SerializeField] private GameObject visualCue;
    private static RoomManager roomManager;
    private static RoomManager _instance;
    private bool isMinigameTriggered; // Mini oyun tetiklendi mi?
    public  bool isCharacterVisible; // Karakter görünür mü?
    public  GameObject player; // Karakteri temsil eden değişken

    private void Start()
    {
        roomManager = FindObjectOfType<RoomManager>();
    }

    private void Awake()
    {
        _playerInRange = false;
        _ballInRange = false;
        visualCue.SetActive(false);

        player = GameObject.FindGameObjectWithTag("Player"); // Karakteri bul ve referansını al

        isMinigameTriggered = false;
        isCharacterVisible = true; // Başlangıçta karakter görünür olsun
    }

    public static RoomManager GetInstance()
    {
        return _instance;
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            _playerInRange = false;
            visualCue.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            _playerInRange = true;
            visualCue.SetActive(true);

            if (targetTriggerName == "MiniGameTrigger" && isMinigameTriggered && !isCharacterVisible)
            {
                // Mini oyun tetiklendi ve daha önce devre dışı bırakılmışsa, karakteri tekrar aktifleştir
                player.SetActive(true);
                isCharacterVisible = true; // Karakter artık görünür durumda
                isMinigameTriggered = false;
            }
        }
        if (collider.gameObject.CompareTag("Ball"))
        {
            _ballInRange = true;
        }
    }
  

    private void Update()
    {
        if (_playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            switch (targetTriggerName)
            {
                case "ColonelTrigger":
                    roomManager.CreateRoom(roomManager.colonelRoom);
                    AdjustCharacterPosition(new Vector3(-12f, -3f, 0f));
                    break;
                case "BarmenTrigger":
                    if (isCharacterVisible)
                    {
                        // Karakter daha önce devre dışı bırakıldıysa, tekrar aktifleştir
                        player.SetActive(true);
                        isCharacterVisible = true; // Karakter artık görünür durumda
                    }
                    roomManager.CreateRoom(roomManager.barmenRoom);
                    AdjustCharacterPosition(new Vector3(-19f, -5.5f, 0f));
                    break;
                case "DiningHallTrigger":
                    roomManager.CreateRoom(roomManager.diningHall);
                    AdjustCharacterPosition(new Vector3(-10f, -7.8f, 0f));
                    break;
                case "InfirmaryTrigger":
                    if (isCharacterVisible)
                    {
                        // Karakter daha önce devre dışı bırakıldıysa, tekrar aktifleştir
                        player.SetActive(true);
                        isCharacterVisible = true; // Karakter artık görünür durumda
                    }
                    roomManager.CreateRoom(roomManager.infirmaryRoom);
                    AdjustCharacterPosition(new Vector3(-10f, -2.5f, 0f));
                    break;
                case "MiniGameTrigger":
                    roomManager.CreateRoom(roomManager.MiniGame);
                    AdjustCharacterPosition(new Vector3(-3f, -0f, 0f));

                    // Karakteri devre dışı bırakma
                    player.SetActive(false);
                    isCharacterVisible = false; // Karakter artık görünmez durumda
                    isMinigameTriggered = true;
                    break;
                case "Microscop":
                    roomManager.CreateRoom(roomManager.Microscop);
                    player.SetActive(false);
                    isCharacterVisible = false; 
                    AdjustCharacterPosition(new Vector3(-0f, -4f, 0f));

                    // Karakteri devre dışı bırakma
                    player.SetActive(false);
                    isCharacterVisible = false; // Karakter artık görünmez durumda
                    isMinigameTriggered = true;
                    break;
                case "CoridorTrigger":
                    if (roomManager.lastPlayerPosition != Vector3.zero)
                    {
                        roomManager.CreateRoom(roomManager.coridor);
                        AdjustCharacterPosition(roomManager.lastPlayerPosition);
                    }
                    else
                    {
                        Debug.LogWarning("Last player position not found!");
                    }
                    break;
                default:
                    Debug.LogWarning("Invalid target trigger name!");
                    break;
            }
        }
    }
    public void TriggerTarget(string targetTriggerName)
    {
        switch (targetTriggerName)
        {
            case "InfirmaryTrigger":
                roomManager.CreateRoom(roomManager.infirmaryRoom);

                if (player != null)
                {
                    player.SetActive(true);
                    isCharacterVisible = true;
                }
                else
                {
                    Debug.LogWarning("Player object not found!");
                }
                break;
            default:
                Debug.LogWarning("Invalid target trigger name!");
                break;
        }
    }

    private void AdjustCharacterPosition(Vector3 newPosition)
    {
        if (player != null)
        {
            roomManager.lastPlayerPosition = player.transform.position; // RoomManager üzerindeki lastPlayerPosition değişkenini güncelle
            player.transform.position = newPosition;

            // Move the camera along with the player
            Camera.main.transform.position = new Vector3(newPosition.x, newPosition.y, Camera.main.transform.position.z);
        }
        else
        {
            Debug.LogWarning("Player object not found!");
        }
    }
}