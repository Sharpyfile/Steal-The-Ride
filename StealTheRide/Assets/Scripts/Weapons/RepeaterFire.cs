using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeaterFire : WeaponFire
{
    public bool isLeverForward;
    public bool isLeverBackward;
    public ParticleSystem particleSystem;
    public int fireParticleCount = 10;
    //public static bool isSuperShot = false;

    private GameObject reloadSliderInstance;


    void Start()
    {
        timestampFiring = Time.time;
        timestampReload = Time.time;
        weaponInfo = "Ready to shoot";
    }

    void Update()
    {
        sumOfBullets = bulletsInMagazine + additionalBullets;

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
                    else if(isLeverForward == false && isLeverBackward == false)
                    {
                        PushForward();
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

        if (Input.GetButtonDown("Reload") && additionalBullets > 0)
        {
            Reload();
        }

    }

    private void Fire()
    {
        Shoot();

        particleSystem.Emit(fireParticleCount);

        AudioManager.instance.Play("RevolverShot");
        bulletsInMagazine--;
        Debug.Log("Firing");
        isLeverForward = false;
        isLeverBackward = false;
        weaponInfo = "Push forward!";

        if (bulletsInMagazine == 0)       
        {
            weaponInfo = "No bullets!";
            Debug.Log("You have no bullets in magazine - reload");
        }
        timestampFiring = Time.time + fireCooldown;
    }


    private void PushForward()
    {
        isLeverForward = true;
        weaponInfo = "Pull back!";
        AudioManager.instance.Play("RevolverCock");
        //Debug.Log("The gun has been reloaded");
        timestampFiring = Time.time + fireCooldown;
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

    public override void StopReloading()
    {
        isReloading = false;
        reloadSlider.SetActive(false);

        if (bulletsInMagazine > 0)
        {
            if (isLeverForward && isLeverBackward)
            {
                weaponInfo = "Ready to shoot";
            }
            else if(isLeverForward)
            {
                weaponInfo = "Pull back!";
            }
            else
            {
                weaponInfo = "Push forward!";
            }
        }
        else
        {
            weaponInfo = "No bullets!";
        }
    }
}
