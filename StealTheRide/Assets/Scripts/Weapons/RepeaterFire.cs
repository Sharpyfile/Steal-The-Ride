using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeaterFire : WeaponFire
{
    public bool isLeverForward;
    public bool isLeverBackward;
    //public static bool isSuperShot = false;

    private GameObject reloadSliderInstance;


    void Start()
    {

        timestampFiring = Time.time;
        timestampReload = Time.time;
    }

    void Update()
    {
        if (!isReloading)
        {
            if (bulletsInMagazine > 0)
            {
                if (Input.GetMouseButtonDown(0) && timestampFiring <= Time.time )
                {
                    if (isLeverForward && isLeverBackward)
                    {
                        Fire();
                    }
                    else
                    {
                        PullForward();
                    }
                }
                if (Input.GetMouseButtonDown(1) && timestampFiring <= Time.time)
                {
                    if (isLeverForward)
                    {
                        PullBack();
                    }
                }


            }
        }

        if (isReloading && timestampReload <= Time.time)
        {
            ReloadTick();
        }

        if (Input.GetButtonDown("Reload"))
        {
            Reload();
        }

    }

    private void Fire()
    {
        if (!player.GetDucked())
        {
            GameObject.Instantiate(bullet, transform.position, transform.rotation).SetActive(true);

            AudioManager.instance.Play("RevolverShot");
            bulletsInMagazine--;
            Debug.Log("Firing");
            isLeverForward = false;
            isLeverBackward = false;
            weaponInfo = "Pull forward!";
            if (bulletsInMagazine == 0)       
            {
                weaponInfo = "No bullets!";
                Debug.Log("You have no bullets in magazine - reload");
            }
            timestampFiring = Time.time + fireCooldown;
        }
    }


    private void PullForward()
    {
        if (isLeverForward == false)
        {
            isLeverForward = true;
            weaponInfo = "Pull back!";
            AudioManager.instance.Play("RevolverCock");
            //Debug.Log("The gun has been reloaded");
            timestampFiring = Time.time + fireCooldown;
        }
        else if (bulletsInMagazine > 0)
        {
            weaponInfo = "Ready to shoot";
            Debug.Log("There is already a bullet in the chamber!");
        }
    }

    private void PullBack()
    {
        if (isLeverBackward == false)
        {
            isLeverBackward = true;
            weaponInfo = "Ready to shoot";
            AudioManager.instance.Play("RevolverCock");
            //Debug.Log("The gun has been reloaded");
            timestampFiring = Time.time + fireCooldown;
        }
        else if (bulletsInMagazine > 0)
        {
            weaponInfo = "Ready to shoot";
            Debug.Log("There is already a bullet in the chamber!");
        }
    }

    
}
