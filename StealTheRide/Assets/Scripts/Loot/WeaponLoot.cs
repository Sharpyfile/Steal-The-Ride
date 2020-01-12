using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class WeaponLoot : MonoBehaviour
{
    public int weaponIndex;
    private GameObject pickupText;

    public int bullets;
    public int Bullets
    {
        get { return bullets; }
        set { bullets = value; }
    }
    public int additionalBullets;
    public int AdditionalBullets
    {
        get { return additionalBullets; }
        set { additionalBullets = value; }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            pickupText = GameObject.Find("Player/Canvas/PickupText");
            pickupText.SetActive(true);
            pickupText.GetComponent<Text>().text = "Press E to pickup";

            if (weaponIndex == 0)
            {
                pickupText.GetComponent<Text>().text += " REVOLVER";
            }
            else if (weaponIndex == 1)
            {
                pickupText.GetComponent<Text>().text += " REPEATER";
            }
            else if (weaponIndex == 2)
            {
                pickupText.GetComponent<Text>().text += " SHOTGUN";
            }
            else if (weaponIndex == 3)
            {
                pickupText.GetComponent<Text>().text += " BOW";
            }

            collider.gameObject.GetComponentInChildren<WeaponSwitching>().WeaponToPickUp = weaponIndex;
            collider.gameObject.GetComponentInChildren<WeaponSwitching>().weaponObjectToPickUp = this;
            collider.gameObject.GetComponentInChildren<WeaponSwitching>().BulletsToPickUp = bullets;
            collider.gameObject.GetComponentInChildren<WeaponSwitching>().AdditionalBulletsToPickUp = additionalBullets;
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            pickupText.SetActive(false);
            collider.gameObject.GetComponentInChildren<WeaponSwitching>().WeaponToPickUp = -1;
            collider.gameObject.GetComponentInChildren<WeaponSwitching>().weaponObjectToPickUp = null;
            collider.gameObject.GetComponentInChildren<WeaponSwitching>().BulletsToPickUp = 0;
            collider.gameObject.GetComponentInChildren<WeaponSwitching>().AdditionalBulletsToPickUp = 0;
        }
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }

    //private void OnTriggerEnter2D(Collider2D collider)
    //{


    //    if (collider.gameObject.tag == "Player" )
    //    {
    //        collider.gameObject.GetComponentInChildren<WeaponSwitching>().FirstWeapon = weaponIndex;
    //        AudioManager.instance.Play("PickupAmmo");
    //        Destroy(gameObject);
    //    }
    //}

    //private void OnTriggerExit2D(Collider2D collider)
    //{
    //    //if (collider.gameObject.tag == "Player")
    //    //{
    //    //    collider.gameObject.GetComponentInChildren<WeaponSwitching>().FirstWeapon = weaponIndex;
    //    //    AudioManager.instance.Play("PickupAmmo");
    //    //    Destroy(gameObject);
    //    //}
    //}
}
