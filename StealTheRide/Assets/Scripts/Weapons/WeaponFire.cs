using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponFire : MonoBehaviour
{
    public bool isReloaded = true;
    public int magazine = 6;
    public int bulletsInMagazine = 6;
    public GameObject bullet;
    private string weaponInfo;
    public float reloadCooldown;
    public float fireCooldown;
    private float timeStampFiring;
    private float timeStampReload;


    public string getWeaponInfo()
    {
        return weaponInfo;
    }

    private void Start()
    {
        timeStampFiring = Time.time;
        timeStampReload = Time.time;
}

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && timeStampFiring <= Time.time)
        {
            if (bulletsInMagazine > 0)
            {
                if (isReloaded)
                {
                    GameObject.Instantiate(bullet, this.transform.position, this.transform.rotation).SetActive(true);

                    bulletsInMagazine--;
                    isReloaded = false;
                    Debug.Log("Firing");
                    weaponInfo = "Load next bullet";
                    timeStampFiring = Time.time + fireCooldown;
                }

                else
                    Debug.Log("You need to load the bullet in the chamber");
                
            }
            else
                Debug.Log("You have no bullets in magazine - reload");

        }

        if (Input.GetMouseButtonDown(1))
        {
            if (isReloaded == false && bulletsInMagazine > 0)
            {
                isReloaded = true;
                Debug.Log("The gun has been reloaded");
                weaponInfo = "Ready to shoot";

            }
                
            else if (bulletsInMagazine > 0)
            {
                Debug.Log("There is already a bullet in the chamber!");
                weaponInfo = "Ready to shoot";
            }
            else
            {
                Debug.Log("You have no bullets in magazine - reload");
                weaponInfo = "No ammo in magazine \nreload";
            }
                
        }

        if (Input.GetButtonDown("Reload") && timeStampReload <= Time.time)
        {
            bulletsInMagazine = magazine;
            isReloaded = true;
            Debug.Log("Reloading");
            weaponInfo = "Reloaded \nready to Shoot";
            timeStampReload = Time.time + reloadCooldown;
            timeStampFiring = Time.time + reloadCooldown;
        }

    }
}
