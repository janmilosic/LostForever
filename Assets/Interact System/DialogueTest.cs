using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueTest : Interactable
{
    public bool dialogue;
    public Image background;
    public TMP_Text next;

    DialogueTrigger dialogueTrigger;

    private void Awake()
    {
        dialogueTrigger = GetComponent<DialogueTrigger>();
    }

    public void Start()
    {
        UpdateDialogue();
    }

    void UpdateDialogue()
    {
        dialogueTrigger.TriggerDialogue();
        background.enabled = true;
        next.enabled = true;
    }

    public override string GetDescription()
    {
        if (dialogue) return "";
        return "";
    }

    public override void Interact()
    {
        dialogue = !dialogue;
        UpdateDialogue();
    }
}
