using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BowFire : WeaponFire
{

    //private GameObject reloadSliderInstance;
    public GameObject bowSlider;

    public float loadIncrease;

    private bool isLoading;
    private bool isPeakReached;
    private float timeBow;

    public float timestampLoad;


    // Start is called before the first frame update
    void Start()
    {
        timestampFiring = Time.time;
        timestampReload = Time.time;
        timestampLoad = Time.time;

        weaponInfo = "Ready to load";
    }

    // Update is called once per frame
    void Update()
    {
        if (PauseMenu.IsPaused)
            return;
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
                if (Input.GetMouseButtonDown(0))
                {
                    isLoading = true;
                }
                if (Input.GetMouseButtonUp(0))
                {
                    if (isLoading == true && timestampFiring <= Time.time)
                        Fire();
                    else
                    {
                        weaponInfo = "Ready to load";
                    }
                }
                if (Input.GetMouseButton(0) && Input.GetMouseButtonDown(1))
                {
                    StopLoadingArrow();
                }
            }
            else
            {
                if (Input.GetMouseButtonDown(0))
                {
                    AudioManager.instance.Play("RevolverEmptyChamber");
                }
            }

            if (bulletsInMagazine == 0 && additionalBullets > 0)
            {
                Reload();

                timestampFiring = Time.time + fireCooldown;
                weaponInfo = "Ready to load";
            }
            else if (bulletsInMagazine == 0 && additionalBullets == 0)
            {
                weaponInfo = "No arrows!";
            }

        }

        if (isReloading && timestampReload <= Time.time)
        {
            ReloadTick();
        }

        if (isLoading && timestampLoad <= Time.time)
        {
            Load();
        }

        //if (Input.GetButtonDown("Reload"))
        //{
        //    Reload();
        //}
    }

    private void Load()
    {
        weaponInfo = "Loading...";
        bowSlider.GetComponent<BowSlider>().Set(speed);

        if (speed >= 10)
        {
            isPeakReached = true;
        }

        if (isPeakReached == false)
        {
            speed += loadIncrease;
            damage += loadIncrease;
            //if (speed < 10)
            //    speed += 0.05f;

            //if (damage < 10)
            //    damage += 0.05f;
        }
        else
        {
            speed -= loadIncrease*2;
            damage -= loadIncrease*2;
            if (speed <= 0.5f)
                speed = 0.5f;

            if (damage <= 0.5f)
                damage = 0.5f;
        }

        timestampLoad = Time.time + 0.01f;
    }

    private void StopLoadingArrow()
    {
        isLoading = false;
        weaponInfo = "Load cancelled";
        bowSlider.GetComponent<BowSlider>().Set(0);
    }

    private void Fire()
    {
        //reloadSlider.SetActive(false);
        SetBullet();
        isLoading = false;
        Shoot();

        AudioManager.instance.Play("BowShot");
        bulletsInMagazine--;
        Debug.Log("Firing");

        bowSlider.GetComponent<BowSlider>().Set(0);

    }

    public void ReloadTick()
    {
        Debug.Log("Loading ...");
        weaponInfo = "Imposing an arrow...";
        bulletsInMagazine++;
        additionalBullets--;
        //AudioManager.instance.Play("RevolverReloadTick");
        if (bulletsInMagazine == magazineSize || additionalBullets == 0)
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
