using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ink.Runtime;

public class DialogueManager : MonoBehaviour
{
  
   [Header("Dialogue UI")]
   [SerializeField] private GameObject dialoguePanel;
   //[SerializeField] private GameObject continueIcon;
   [SerializeField] private TextMeshProUGUI dialogueText;
   //[SerializeField] private TextMeshProUGUI displayNameText;

   private Story _currentStory;
   private bool _dialogueIsPlaying;
   private static DialogueManager _instance;

   private void Awake()
   {
      if (_instance != null)
      {
         Debug.LogWarning("Found more than one Dialogue Manager in the scene");
      }
      _instance = this;
   }
   public static DialogueManager GetInstance() 
   {
      return _instance;
   }

   private void Start()
   {
      _dialogueIsPlaying = false;
      dialoguePanel.SetActive(false);
   }

   private void Update()
   {
      if (!_dialogueIsPlaying) 
      {
         return;
      }

      if (Input.GetKeyDown(KeyCode.Space))
      {
         ContinueStory();
      }
   }

   public void EnterDialogueMode(TextAsset inkJSON)
   {
      _currentStory = new Story(inkJSON.text);
      _dialogueIsPlaying = true;
      dialoguePanel.SetActive(true);
      ContinueStory();

   }

   private void ExitDialogueMode()
   {
      _dialogueIsPlaying = false;
      dialoguePanel.SetActive(false);
      dialogueText.text = "";
   }

   private void ContinueStory()
   {
      if (_currentStory.canContinue)
      {
         dialogueText.text = _currentStory.Continue();
      }
      else
      {
         ExitDialogueMode();
      }
   }
   
}
