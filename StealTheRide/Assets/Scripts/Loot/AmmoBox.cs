﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoBox : MonoBehaviour
{
    public int minBullets = 1;
    public int maxBullets = 5;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponentInChildren<WeaponSwitching>().weaponScript.additionalBullets += Random.Range(minBullets, maxBullets);
            AudioManager.instance.Play("PickupAmmo");
            Destroy(gameObject);
        }
    }
}
