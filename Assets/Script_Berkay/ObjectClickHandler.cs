using UnityEngine;

public class ObjectClickHandler : MonoBehaviour
{
    public string targetTriggerName;
    private DoorScript doorManager;

    private void Start()
    {
        doorManager = FindObjectOfType<DoorScript>();
    }

    
    private void OnMouseDown()
    {
        
            doorManager.TriggerTarget("InfirmaryTrigger");

    }
}