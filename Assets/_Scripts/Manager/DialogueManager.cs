using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class DialogueManager : MonoBehaviour
{
    public Image actorImage;
    public TMP_Text actorName;
    public TMP_Text messageText;
    public RectTransform backgroundBox;
    public GameObject jock; 

    Message[] currentMessages;
    Actor[] currentActors;
    public Tree vtree;
    public UpgradeAreaManager varea;
    int activeMessage = 0;
    public static bool isActive = false;

    public void OpenDialogue(Message[] messages, Actor[] actors)
    {
        jock.gameObject.SetActive(false);
        currentMessages = messages;
        currentActors = actors;
        activeMessage = 0;
        isActive = true; 

        DisplayMessage();
        backgroundBox.LeanScale(Vector3.one, 0.5f).setEaseInOutExpo();
    }
    void DisplayMessage()
    {
        Message messageToDisplay = currentMessages[activeMessage];
        messageText.text = messageToDisplay.message;

        Actor actorToDisplay = currentActors[messageToDisplay.actorId];  
        actorName.text = actorToDisplay.name;
        actorImage.sprite = actorToDisplay.sprite;

        AnimateTextColor();
    }
    public void NextMessage()
    {
        activeMessage++;
        if (activeMessage < currentMessages.Length)
        {
            DisplayMessage();
        }else
        {
            Debug.Log("Conversation ended!");
            backgroundBox.LeanScale(Vector3.zero, 0.5f).setEaseInOutExpo();
            if (SceneManager.GetActiveScene().name == "Europa")
            {
                vtree.dialogueEuropaTrigger1.SetActive(false);
                vtree.dialogueEuropaTrigger2.SetActive(false);
                vtree.dialogueEuropaTrigger3.SetActive(false);
                vtree.dialogueEuropaTrigger4.SetActive(false);
            }
            if (SceneManager.GetActiveScene().name == "Africa")
            {
                vtree.dialogueAfricaTrigger1.SetActive(false);
                vtree.dialogueAfricaTrigger2.SetActive(false);
                vtree.dialogueAfricaTrigger3.SetActive(false);
                vtree.dialogueAfricaTrigger4.SetActive(false);
                vtree.dialogueAfricaTrigger5.SetActive(false);
            }
            if (SceneManager.GetActiveScene().name == "Oceania")
            {
                vtree.dialogueOceaniaTrigger1.SetActive(false);
                vtree.dialogueOceaniaTrigger2.SetActive(false);
                vtree.dialogueOceaniaTrigger3.SetActive(false);
                vtree.dialogueOceaniaTrigger4.SetActive(false);
                vtree.dialogueOceaniaTrigger5.SetActive(false);
            }
            isActive = false;
            jock.gameObject.SetActive(true);
        }
    }

    void AnimateTextColor()
    {
        
        LeanTween.textAlpha(messageText.rectTransform, 0, 0);
        LeanTween.textAlpha(messageText.rectTransform, 1, 0.5f);
    }
    void Start() 
    {    
        vtree = FindAnyObjectByType<Tree>();
        
        
        backgroundBox.transform.localScale = Vector3.zero;
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isActive == true)
        {
            NextMessage();
        }
    }

    void OnMouseDown()
    {
        NextMessage();
    }
}



// public class DialogueManager : MonoBehaviour
// {
//     public Image actorImage;
//     public TMP_Text actorName;
//     public TMP_Text messageText;

//     Dialogue[] currentMessages;
//     Actor[] currentActors;
//     public Animator animator;
//     private Queue<string> sentences;
//     int activeMessage = 0;

//     void Start()
//     {
//         sentences = new Queue<string>();
//     }

//     public void StartDialogue(Dialogue[] dialogue, Actor[] actors)
//     {
//         currentMessages = dialogue;
//         currentActors = actors;
//         activeMessage = 0;

//         animator.SetBool("IsOpen", true);
//         actorName.text = currentActors[currentMessages[activeMessage].actorId].name;
//         actorImage.sprite = currentActors[currentMessages[activeMessage].actorId].sprite;

//         sentences.Clear();

//         foreach (string sentence in currentMessages[activeMessage].sentences)
//         {
//             sentences.Enqueue(sentence);
//         }

//         DisplayNextSentence();
//     }

//     public void DisplayNextSentence()
//     {
//         if (sentences.Count == 0)
//         {
//             EndDialogue();
//             return;
//         }

//         string sentence = sentences.Dequeue();
//         StopAllCoroutines();
//         StartCoroutine(TypeSentence(sentence));
//     }

//     IEnumerator TypeSentence(string sentence)
//     {
//         messageText.text = "";
//         foreach (char letter in sentence.ToCharArray())
//         {
//             messageText.text += letter;
//             yield return null;
//         }
//     }

//     void EndDialogue()
//     {
//         animator.SetBool("IsOpen", false);
//     }
// }


// DIALOGUE MANAGER OLD MODFY
// using System;
// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;
// using TMPro;

// public class DialogueManager : MonoBehaviour
// {
//     public TMP_Text nameText;
//     public TMP_Text dialogueText;
//     public Animator animator;
//     private Queue<string> sentences;

//     void Start()
//     {
//         sentences = new Queue<string>();
//     }

//      public void StartDialogue (Dialogue dialogue)
//     {
//         animator.SetBool("IsOpen", true);
//         nameText.text = dialogue.name;

//         sentences.Clear();

//         foreach(string sentence in dialogue.sentences)
//         {
//             sentences.Enqueue(sentence);
//         }
//         DisplayNextSentence();

//     }
    
//     public void DisplayNextSentence()
//     {
//         if (sentences.Count == 0)
//         {
//             EndDialogue();
//             return;
//         }

//         string sentence = sentences.Dequeue();
//         StopAllCoroutines();
//         StartCoroutine(TypeSentence(sentence));
//     }

//     IEnumerator TypeSentence (string sentence)
//     {
//         dialogueText.text = "";
//         foreach(char letter in sentence.ToCharArray())
//         {
//             dialogueText.text += letter;
//             yield return null;
//         }
//     }

//     void EndDialogue()
//     {
//         animator.SetBool("IsOpen", false);
//     }

// }


// DIALOGUE MANAGER NEW 
// public class DialogueManager : MonoBehaviour
// {
//     public Image actorImage;
//     public TMP_Text actorName;
//     public TMP_Text messageText;

//     Message[] currentMessages;
//     Actor[] currentActors;
//     public Animator animator;
//     int activeMessage = 0;
    

//     public void OpenDialogue(Message[] messages, Actor[] actors)
//     {
//         currentMessages = messages;
//         currentActors = actors;
//         activeMessage = 0;
//         animator.SetBool("IsOpen", true);   

//         Debug.Log("Started conversation! Loaded messages: " + messages.Length);
//         DisplayMessage();
//     }
//     void DisplayMessage()
//     {
//         Message messageToDisplay = currentMessages[activeMessage];
//         messageText.text = messageToDisplay.message;

//         Actor actorToDisplay = currentActors[messageToDisplay.actorId];  
//         actorName.text = actorToDisplay.name;
//         actorImage.sprite = actorToDisplay.sprite;
//         DisplayNextSentence();
//     }
//     public void DisplayNextSentence()
//     {
//         if (activeMessage <= currentMessages.Length -1)
//         {
//             EndDialogue();
//             return;
//         }
//         //fila
//         activeMessage++;

//         StopAllCoroutines();
//         StartCoroutine(TypeSentence(currentMessages[activeMessage].message));
//     }

//     IEnumerator TypeSentence (string sentence)
//     {
//         messageText.text = "";
//         foreach(char letter in sentence.ToCharArray())
//         {
//             messageText.text += letter;
//             yield return null;
//         }
//     }
//     void EndDialogue()
//     {
//         animator.SetBool("IsOpen", false);
//     }
// }

