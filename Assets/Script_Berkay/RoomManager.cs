using UnityEngine;

public class RoomManager : MonoBehaviour
{
    #region Self Variables

    public GameObject colonelRoom;
    public GameObject barmenRoom;
    public GameObject diningHall;
    public GameObject infirmaryRoom;
    public GameObject coridor;
    public GameObject Microscop;
    public GameObject Bag;
    public Vector3 lastPlayerPosition;
    
    public GameObject MiniGame;
    #endregion
    public static bool isCharacterVisible; // Karakter görünür mü?
    public static GameObject player;
    private GameObject currentRoom;

    public void Start()
    {
        CreateRoom(coridor);
    }
    


    public void CreateRoom(GameObject roomPrefab)
    {
        if (currentRoom != null)
        {
            Destroy(currentRoom);
        }
        currentRoom = Instantiate(roomPrefab, Vector3.zero, Quaternion.identity);
    }
}