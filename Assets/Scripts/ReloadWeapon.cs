using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReloadWeapon : MonoBehaviour
{

    public Animator rigController;
    public WeaponAnimationEvents animationEvents;
    public ActiveWeapon activeWeapon;
    public Transform leftHand;
    public AmmoWidget ammoWidget;

    GameObject magazineHand;

    void Start()
    {
        animationEvents.WeaponAnimationEvent.AddListener(OnAnimationEvent);
    }

    void Update()
    {
        RaycastWeapon weapon = activeWeapon.GetActiveWeapon();
        if (weapon)
        {
            if (Input.GetKeyDown(KeyCode.R)) //  || weapon.ammoCount <= 0
            {
                rigController.SetTrigger("reload_weapon");
                FindObjectOfType<AudioManager>().Play("GunReload");
            }
            if (weapon.isFiring)
            {
                ammoWidget.Refresh(weapon.ammoCount);
            }
        }
    }

    void OnAnimationEvent(string eventName)
    {
        Debug.Log(eventName);
        switch (eventName)
        {
            case "detach_magazine":
                DetachMagazine();
                break;
            case "drop_magazine":
                DropMagazine();
                break;
            case "refill_magazine":
                RefillMagazine();
                break;
            case "attach_magazine":
                AttachMagazine();
                break;
        }
    }

    void DetachMagazine()
    {
        RaycastWeapon weapon = activeWeapon.GetActiveWeapon();
        magazineHand = Instantiate(weapon.magazine, leftHand, true);
        weapon.magazine.SetActive(false);
    }

    void DropMagazine()
    {
        GameObject droppedMagazine = Instantiate(magazineHand, magazineHand.transform.position, magazineHand.transform.rotation);
        droppedMagazine.AddComponent<Rigidbody>();
        droppedMagazine.AddComponent<BoxCollider>();
        magazineHand.SetActive(false);
    }

    void RefillMagazine()
    {
        magazineHand.SetActive(true);
    }

    void AttachMagazine()
    {
        RaycastWeapon weapon = activeWeapon.GetActiveWeapon();
        weapon.magazine.SetActive(true);
        Destroy(magazineHand);
        weapon.ammoCount = weapon.clipSize;
        rigController.ResetTrigger("reload_weapon");

        ammoWidget.Refresh(weapon.ammoCount);
    }

}
