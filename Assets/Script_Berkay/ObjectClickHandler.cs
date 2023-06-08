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
        if (tag == "Inf")
        {
            doorManager.TriggerTarget("InfirmaryTrigger");
        }
        else
        {
            doorManager.TriggerTarget("CornelTrigger");
        }
    }
}