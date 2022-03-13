using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{

    public TMP_Text nameText;
    public TMP_Text dialogueText;

    public GameObject dialogueBox;

    public float typingSpeed = 0.02f;

    private Queue<string> sentences;

    void Start()
    {
        sentences = new Queue<string>();

    }

    public void StartDialogue (Dialogue dialogue)
    {
        dialogueBox.SetActive(true);

        nameText.text = dialogue.name;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    void EndDialogue()
    {
        Debug.Log("End of conversation");
        dialogueBox.SetActive(false);
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (sentences.Count != 0)
            {
                DisplayNextSentence();
            } else
            {
                EndDialogue();
            }
            
        }
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }


}
