using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WeaponPickUp : MonoBehaviour
{
    public RaycastWeapon weaponFab;

    public bool active;

    public Image background;
    public TMP_Text next;

    public GameObject ammo;

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
        ActiveWeapon activeWeapon = other.gameObject.GetComponent<ActiveWeapon>();
        if (activeWeapon)
        {
            RaycastWeapon newWeapon = Instantiate(weaponFab);
            activeWeapon.Equip(newWeapon);
        }

        if (active == false)
        {
            UpdateDialogue();
            active = true;
            ammo.SetActive(true);
        }
    }

    void UpdateDialogue()
    {
        dialogueTrigger.TriggerDialogue();
        background.enabled = true;
        next.enabled = true;
    }
}
