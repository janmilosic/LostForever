using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GunDialogue : Interactable
{
    public bool dialogue;
    public Image background;
    public TMP_Text next;

    public bool active;

    public GameObject ToContinue;

    DialogueTrigger dialogueTrigger;

    private void Awake()
    {
        dialogueTrigger = GetComponent<DialogueTrigger>();
    }

    public void Start()
    {
        if (active == false)
        {
            UpdateDialogue();
        }

    }

    void UpdateDialogue()
    {
        dialogueTrigger.TriggerDialogue();
        background.enabled = true;
        next.enabled = true;
        active = true;
        ToContinue.SetActive(true);
    }

    public override string GetDescription()
    {
        if (dialogue) return "";
        return "";
    }

    public override void Interact()
    {

        if (active == false)
        {
            UpdateDialogue();
            dialogue = !dialogue;
        }
    }
}

