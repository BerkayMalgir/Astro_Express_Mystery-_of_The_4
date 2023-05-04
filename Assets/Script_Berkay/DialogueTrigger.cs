using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Message[] massages;
    public Actor[] actors;

}
[System.Serializable]
public class Message
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
    
        
    

