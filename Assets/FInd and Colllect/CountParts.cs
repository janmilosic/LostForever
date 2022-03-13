using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CountParts : MonoBehaviour
{
    public int count;
    public int all = 4;
    public bool active;

    public Image background;
    public TMP_Text next;
    public GameObject ai1;
    public GameObject ai2;
    public GameObject aiTrigger;

    DialogueTrigger dialogueTrigger;

    private void Awake()
    {
        dialogueTrigger = GetComponent<DialogueTrigger>();
    }

    private void Start()
    {
        active = false;
    }

    void Update()
    {

        if (active == false)
        {
            if (count == all)
            {
                UpdateDialogue();
                active = true;
                Destroy(ai1);
                aiTrigger.SetActive(true);
                ai2.SetActive(true);
            }
        }
    }

    void UpdateDialogue()
    {
        dialogueTrigger.TriggerDialogue();
        background.enabled = true;
        next.enabled = true;
    }
}
