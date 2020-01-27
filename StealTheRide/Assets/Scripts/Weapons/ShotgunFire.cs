using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunFire : WeaponFire
{
    public ParticleSystem particleSystem;
    public int fireParticleCount = 8;

    private GameObject reloadSliderInstance;

    // Start is called before the first frame update
    void Start()
    {
        timestampFiring = Time.time;
        timestampReload = Time.time;
        isLeftChamberFull = true;
        isRightChamberFull = true;
        weaponInfo = "Both chambers full";
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
                if (Input.GetMouseButtonDown(0) && Input.GetMouseButtonDown(1) && isLeftChamberFull == true && isRightChamberFull == true && timestampFiring <= Time.time)
                {
                    SuperFire();
                }
                else if (Input.GetMouseButtonDown(0) && isLeftChamberFull == true && timestampFiring <= Time.time)
                {
                    LeftFire();
                }
                else if (Input.GetMouseButtonDown(1) && isRightChamberFull == true && timestampFiring <= Time.time)
                {
                    RightFire();
                }

            }
            else
            {
                if (Input.GetMouseButtonDown(0))
                {
                    AudioManager.instance.Play("RevolverEmptyChamber");
                }
            }
        }

        if (bulletsInMagazine == 0 && isR == false)
        {
            Vector3 newPosition = firePoint.position + new Vector3(0.0f, 0.5f, 0.0f);
            GameObject newR = GameObject.Instantiate(r, newPosition, Quaternion.identity);
            isR = true;
            StartCoroutine(MyDestroy(0.3f, newR));
            //Destroy(newR);
        }

        if (isReloading && timestampReload <= Time.time)
        {
            ReloadTick();
        }

        if (Input.GetButtonDown("Reload") && additionalBullets > 0)
        {
            Reload();
        }

        if (isReloading && Input.GetKeyDown(KeyCode.Alpha2))
        {
            StopReloading();
        }
    }

    private void LeftFire()
    {
        Shoot();

        particleSystem.Emit(fireParticleCount);

        AudioManager.instance.Play("RevolverShot");

        bulletsInMagazine--;
        isLeftChamberFull = false;
        Debug.Log("Firing");

        if (bulletsInMagazine == 0)
        {
            weaponInfo = "No bullets!";
            Debug.Log("You have no bullets in magazine - reload");
        }
        else
        {
            weaponInfo = "Right bullet ready";
        }
        timestampFiring = Time.time + fireCooldown;

        //AudioManager.instance.Play("RevolverCock");
        StartCoroutine(playSoundWithDelay(0.05f));
    }

    private void RightFire()
    {
        Shoot();

        particleSystem.Emit(fireParticleCount);

        AudioManager.instance.Play("RevolverShot");

        bulletsInMagazine--;
        isRightChamberFull = false;
        Debug.Log("Firing");

        if (bulletsInMagazine == 0)
        {
            weaponInfo = "No bullets!";
            Debug.Log("You have no bullets in magazine - reload");
        }
        else
        {
            weaponInfo = "Left bullet ready";
        }
        timestampFiring = Time.time + fireCooldown;

        //AudioManager.instance.Play("RevolverCock");
        StartCoroutine(playSoundWithDelay(0.05f));
    }

    private void SuperFire()
    {
        Shoot();
        Shoot();

        particleSystem.Emit(fireParticleCount);
        particleSystem.Emit(fireParticleCount);
        particleSystem.Emit(fireParticleCount);


        AudioManager.instance.Play("RevolverShot");
        AudioManager.instance.Play("RevolverShot");
        bulletsInMagazine--;
        bulletsInMagazine--;
        isLeftChamberFull = false;
        isRightChamberFull = false;
        Debug.Log("Firing");

        if (bulletsInMagazine == 0)
        {
            weaponInfo = "No bullets!";
            Debug.Log("You have no bullets in magazine - reload");
        }
        timestampFiring = Time.time + fireCooldown;

        StartCoroutine(playSoundWithDelay(0.05f));
    }

    IEnumerator playSoundWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        AudioManager.instance.Play("RevolverCock");
    }

    public void ReloadTick()
    {
        Debug.Log("Loading bullet...");
        weaponInfo = "Reloading...";
        bulletsInMagazine++;
        additionalBullets--;
        AudioManager.instance.Play("RevolverReloadTick");
        if (isLeftChamberFull == false)
        {
            isLeftChamberFull = true;
        }
        else
        {
            isRightChamberFull = true;
        }

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

        if (bulletsInMagazine == magazineSize)
        {
            weaponInfo = "Both chambers full";
        }
        else if (bulletsInMagazine == 1)
        {
            weaponInfo = "Left bullet ready";
        }
        else
        {
            weaponInfo = "No bullets!";
        }
    }
}