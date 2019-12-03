using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BowFire : WeaponFire
{

    //private GameObject reloadSliderInstance;
    public GameObject bowSlider;


    private bool isStopped;
    private bool isPeakReached;
    private float timeBow;


    // Start is called before the first frame update
    void Start()
    {
        timestampFiring = Time.time;
        timestampReload = Time.time;
        weaponInfo = "Ready to load";
    }

    // Update is called once per frame
    void Update()
    {
        sumOfBullets = bulletsInMagazine + additionalBullets;

        if (!isReloading)
        {
            if (bulletsInMagazine > 0)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    speed = 1.0f;
                    damage = 1.0f;
                    isPeakReached = false;
                    timeBow = Time.time;
                }
                if (Input.GetMouseButton(0))
                {
                    Load();
                }
                if (Input.GetMouseButtonUp(0))
                {
                    if (isStopped == false && timestampFiring <= Time.time)
                        Fire();
                    else
                    {
                        isStopped = false;
                        weaponInfo = "Ready to load";
                    }
                }
                if (Input.GetMouseButton(0) && Input.GetMouseButtonDown(1))
                {
                    StopLoadingArrow();
                }
            }
           

        }

        if (isReloading && timestampReload <= Time.time)
        {
            ReloadTick();
        }

        //if (Input.GetButtonDown("Reload"))
        //{
        //    Reload();
        //}
    }

    private void Load()
    {
        if(isStopped == false)
        {
            weaponInfo = "Loading...";
            bowSlider.GetComponent<BowSlider>().Set(speed);
        }
        if (speed >= 10)
        {
            isPeakReached = true;
        }

        if (isPeakReached == false)
        {
            speed += 0.25f;
            damage += 0.25f;
            //if (speed < 10)
            //    speed += 0.05f;

            //if (damage < 10)
            //    damage += 0.05f;
        }
        else
        {
            speed -= 0.5f;
            damage -= 0.5f;
            if (speed <= 0.5f)
                speed = 0.5f;

            if (damage <= 0.5f)
                damage = 0.5f;
        }


    }

    private void StopLoadingArrow()
    {
        isStopped = true;
        weaponInfo = "Load cancelled";
        bowSlider.GetComponent<BowSlider>().Set(0);
    }

    private void Fire()
    {
        //reloadSlider.SetActive(false);
        SetBullet();

        Shoot();

        AudioManager.instance.Play("BowShot");
        bulletsInMagazine--;
        Debug.Log("Firing");

        bowSlider.GetComponent<BowSlider>().Set(0);

        Reload();

        //if (bulletsInMagazine == 0)
        //{
        //    weaponInfo = "No bullets!";
        //    Debug.Log("You have no bullets in magazine - reload");
        //}
        timestampFiring = Time.time + fireCooldown;
        weaponInfo = "Ready to load";
    }

    public void ReloadTick()
    {
        Debug.Log("Loading ...");
        weaponInfo = "Imposing an arrow...";
        bulletsInMagazine++;
        //AudioManager.instance.Play("RevolverReloadTick");
        if (bulletsInMagazine == magazineSize)
        {
            StopReloading();
            Debug.Log("Fully reloaded!");
        }
        else
        {
            timestampReload = Time.time + reloadTime;
        }
    }

    public override void StopReloading()
    {
        isReloading = false;
        reloadSlider.SetActive(false);
        //weaponInfo = "";

        if (bulletsInMagazine == magazineSize)
        {
            weaponInfo = "Ready to load";
        }
    }

}
