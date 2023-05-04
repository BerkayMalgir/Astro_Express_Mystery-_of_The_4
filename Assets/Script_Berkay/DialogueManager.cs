using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Image actorImage;
    public Text actorName;
    public Text messageText;
    public RectTransform backgroundBox;

    Message[] currentMessages;
    Actor[] currentActor;
    int activeMessage = 0;
    public static bool IsActive = false;

    public void OpenDialogue(Message[] messages, Actor[] actors)
    {
        currentActor = actors;
        currentMessages = messages;
        activeMessage = 0;
        IsActive = true;
        DisplayMessage();
    }

    void DisplayMessage()
    {
        Message messageToDisplay = currentMessages[activeMessage];
        messageText.text = messageToDisplay.massage;

        Actor actorToDisplay = currentActor[messageToDisplay.actorID];
        actorName.text = actorToDisplay.name;
        actorImage.sprite = actorToDisplay.sprite;
    }

    public void NextMessage()
    {
        activeMessage++;
        if (activeMessage < currentMessages.Length)
        {
            DisplayMessage();
        }
        else
        {
            IsActive = false;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)&& IsActive==true)
        {
            NextMessage();
        }
    }
}
