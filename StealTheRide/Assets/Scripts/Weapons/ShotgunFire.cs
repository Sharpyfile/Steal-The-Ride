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
    }

    // Update is called once per frame
    void Update()
    {
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

    private void LeftFire()
    {
        if (!player.GetDucked())
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
            timestampFiring = Time.time + fireCooldown;

            //AudioManager.instance.Play("RevolverCock");
            StartCoroutine(playSoundWithDelay(0.05f));
        }
    }

    private void RightFire()
    {
        if (!player.GetDucked())
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
            timestampFiring = Time.time + fireCooldown;

            //AudioManager.instance.Play("RevolverCock");
            StartCoroutine(playSoundWithDelay(0.05f));
        }
    }

    private void SuperFire()
    {
        if (!player.GetDucked())
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
    }

    IEnumerator playSoundWithDelay( float delay)
    {
        yield return new WaitForSeconds(delay);
        AudioManager.instance.Play("RevolverCock");
    }

    public void ReloadTick()
    {
        Debug.Log("Loading bullet...");
        weaponInfo = "Reloading...";
        bulletsInMagazine++;
        AudioManager.instance.Play("RevolverReloadTick");
        if(isLeftChamberFull == false)
        {
            isLeftChamberFull = true;
        }
        else
        {
            isRightChamberFull = true;
        }

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
}
