using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public string targetTriggerName;
    private bool _playerInRange;
    [Header("Visual Cue")]
    [SerializeField] private GameObject visualCue;
    private RoomManager roomManager;

    private void Start()
    {
        roomManager = FindObjectOfType<RoomManager>();
    }
    private void Awake()
    {
        _playerInRange = false;
        visualCue.SetActive(false);
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
                    AdjustCharacterPosition(new Vector3(-10f, -2f, 0f));
                    break;
                case "BarmenTrigger":
                    roomManager.CreateRoom(roomManager.barmenRoom);
                    AdjustCharacterPosition(new Vector3(-19f, -6f, 0f));
                    break;
                case "DiningHallTrigger":
                    roomManager.CreateRoom(roomManager.diningHall);
                    AdjustCharacterPosition(new Vector3(-10f, -2f, 0f));
                    break;
                case "InfirmaryTrigger":
                    roomManager.CreateRoom(roomManager.infirmaryRoom);
                    AdjustCharacterPosition(new Vector3(-10f, -2f, 0f));
                    break;
                case "CoridorTrigger":
                    roomManager.CreateRoom(roomManager.coridor);
                    AdjustCharacterPosition(new Vector3(-10f, -2f, 0f));
                    break;
                default:
                    Debug.LogWarning("Invalid target trigger name!");
                    break;
            }
        }
    }
    private void AdjustCharacterPosition(Vector3 newPosition)
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
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