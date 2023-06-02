
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public string targetTriggerName; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            RoomManager roomManager = FindObjectOfType<RoomManager>();
            if (roomManager != null)
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
}

