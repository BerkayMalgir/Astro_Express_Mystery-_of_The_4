using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Massage[] massages;
    public Actor[] actors;

}
[System.Serializable]
public class Massage
{
        public int actorID;
        public string massage;
}
[System.Serializable]
public class Actor
{ 
        public string name;
        public Sprite sprite;
}
    
        
    

