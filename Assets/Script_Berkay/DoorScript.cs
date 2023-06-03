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
                    break;
                case "BarmenTrigger":
                    roomManager.CreateRoom(roomManager.barmenRoom);
                    break;
                case "DiningHallTrigger":
                    roomManager.CreateRoom(roomManager.diningHall);
                    break;
                case "InfirmaryTrigger":
                    roomManager.CreateRoom(roomManager.infirmaryRoom);
                    break;
                case "CoridorTrigger":
                    roomManager.CreateRoom(roomManager.coridor);
                    break;
                default:
                    Debug.LogWarning("Invalid target trigger name!");
                    break;
            }
        }
    }
}