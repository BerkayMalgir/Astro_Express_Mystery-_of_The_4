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
   [SerializeField] private TextMeshProUGUI displayNameText;
   [SerializeField] private Animator portraitAnimator;
   
   [Header("Choices UI")]
   [SerializeField] private GameObject[] choices;
   private TextMeshProUGUI[] _choicesText;

   private Story _currentStory;
   public bool _dialogueIsPlaying { get; private set; }
   private static DialogueManager _instance;
   
   private const string SPEAKER_TAG = "speaker";
   private const string PORTRAIT_TAG = "portrait";
   private const string LAYOUT_TAG = "layout";

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
         
         HandleTags(_currentStory.currentTags);
      }
      else
      {
         ExitDialogueMode();
      }
   }

   private void DisplayChoices() 
   {
      List<Choice> currentChoices = _currentStory.currentChoices;

      // defensive check to make sure our UI can support the number of choices coming in
      if (currentChoices.Count > choices.Length)
      {
         Debug.LogError("More choices were given than the UI can support. Number of choices given: " 
                        + currentChoices.Count);
      }

      int index = 0;
      // enable and initialize the choices up to the amount of choices for this line of dialogue
      foreach(Choice choice in currentChoices) 
      {
         choices[index].gameObject.SetActive(true);
         _choicesText[index].text = choice.text;
         index++;
      }
      // go through the remaining choices the UI supports and make sure they're hidden
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
      EventSystem.current.SetSelectedGameObject(choices[0].gameObject);
   }
   public void MakeChoice(int choiceIndex)
   {
         _currentStory.ChooseChoiceIndex(choiceIndex);
         
         ContinueStory();
      
   }
   
   private void HandleTags(List<string> currentTags)
   {
      // loop through each tag and handle it accordingly
      foreach (string tag in currentTags) 
      {
         // parse the tag
         string[] splitTag = tag.Split(':');
         if (splitTag.Length != 2) 
         {
            Debug.LogError("Tag could not be appropriately parsed: " + tag);
         }
         string tagKey = splitTag[0].Trim();
         string tagValue = splitTag[1].Trim();
            
         // handle the tag
         switch (tagKey) 
         {
            case SPEAKER_TAG:
               displayNameText.text = tagValue;
               break;
            case PORTRAIT_TAG:
               portraitAnimator.Play(tagValue);
               break;
            default:
               Debug.LogWarning("Tag came in but is not currently being handled: " + tag);
               break;
         }
      }
   }

}