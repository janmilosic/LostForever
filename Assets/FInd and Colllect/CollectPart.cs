using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CollectPart : Interactable
{
    public bool dialogue;
    public Image background;
    public TMP_Text next;

    public bool active;

    DialogueTrigger dialogueTrigger;

    public CountParts countParts;

    private void Awake()
    {
        dialogueTrigger = GetComponent<DialogueTrigger>();
        countParts = FindObjectOfType<CountParts>();

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
            dialogue = !dialogue;
            countParts.count++;
            Debug.Log(countParts.count);
            UpdateDialogue();
            Destroy(gameObject);
        }
    }
}

