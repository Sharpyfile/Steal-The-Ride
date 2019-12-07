using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponLoot : MonoBehaviour
{
    public int weaponIndex;
    public GameObject pickupText;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            pickupText.SetActive(true);
            collider.gameObject.GetComponentInChildren<WeaponSwitching>().WeaponToPickUp = weaponIndex;
            collider.gameObject.GetComponentInChildren<WeaponSwitching>().weaponObjectToPickUp = this;
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            pickupText.SetActive(false);
            collider.gameObject.GetComponentInChildren<WeaponSwitching>().WeaponToPickUp = -1;
            collider.gameObject.GetComponentInChildren<WeaponSwitching>().weaponObjectToPickUp = null;
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
