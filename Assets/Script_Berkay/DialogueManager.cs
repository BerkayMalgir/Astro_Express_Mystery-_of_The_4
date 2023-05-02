using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Image actorImage;
    public Text actorName;
    public Text massageText;
    public RectTransform backgroundBox;

    private Massage[] currentMessages;
    private Actor[] currentActor;
    private int activeMessage = 0;

    public void OpenDialogue(Massage[] messages, Actor[] actors)
    {
        currentActor = actors;
        currentMessages = messages;
        activeMessage = 0;
        
        
    }
}
