using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ink.Runtime;
using UnityEngine.EventSystems;

public class DialogueManager : MonoBehaviour
{
  
   [Header("Dialogue UI")]
   [SerializeField] private GameObject dialoguePanel;
   //[SerializeField] private GameObject continueIcon;
   [SerializeField] private TextMeshProUGUI dialogueText;
   //[SerializeField] private TextMeshProUGUI displayNameText;
   
   [Header("Choices UI")]
   [SerializeField] private GameObject[] choices;
   private TextMeshProUGUI[] _choicesText;

   private Story _currentStory;
   public bool _dialogueIsPlaying { get; private set; }
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
      
      
      _choicesText = new TextMeshProUGUI[choices.Length];
      int index = 0;
      foreach (GameObject choice in choices) 
      {
         _choicesText[index] = choice.GetComponentInChildren<TextMeshProUGUI>();
         index++;
      }
      
   }

   private void Update()
   {
      if (!_dialogueIsPlaying) 
      {
         return;
      }

      if (Input.GetKeyDown(KeyCode.Space) )
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
         DisplayChoices();
      }
      else
      {
         ExitDialogueMode();
      }
   }

   private void DisplayChoices()
   {
      List<Choice> currentChoices = _currentStory.currentChoices;
      if (currentChoices.Count > choices.Length)
      {
         Debug.LogError("More choices were given than the UI can support. Number of choices given: " 
                        + currentChoices.Count);
      }
      int index = 0;
      
      foreach(Choice choice in currentChoices) 
      {
         choices[index].gameObject.SetActive(true);
         _choicesText[index].text = choice.text;
         index++;
      }
      for (int i = index; i < choices.Length; i++) 
      {
         choices[i].gameObject.SetActive(false);
      }

      StartCoroutine(SelectFirstChoice());
   }

   private IEnumerator SelectFirstChoice()
   {

      EventSystem.current.SetSelectedGameObject(null);
      yield return new WaitForEndOfFrame();
   }
   public void MakeChoice(int choiceIndex)
   {
     
         _currentStory.ChooseChoiceIndex(choiceIndex);
      
      
   }

}
