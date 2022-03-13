using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnterCaveGun : MonoBehaviour
{
    public bool active;

    public Image background;
    public TMP_Text next;

    public GameObject gun;

    DialogueTrigger dialogueTrigger;

    private void Awake()
    {
        dialogueTrigger = GetComponent<DialogueTrigger>();
    }

    private void Start()
    {
        active = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (active == false)
        {
            UpdateDialogue();
            active = true;
            gun.SetActive(true);
        }

    }

    void UpdateDialogue()
    {
        dialogueTrigger.TriggerDialogue();
        background.enabled = true;
        next.enabled = true;
    }

}

