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
    }

    // Update is called once per frame
    void Update()
    {
        if (!isReloading)
        {
            if (bulletsInMagazine > 0)
            {
                if (Input.GetMouseButtonDown(0) && Input.GetMouseButtonDown(1) && bulletsInMagazine == 2 && timestampFiring <= Time.time)
                {
                    SuperFire();
                }
                else if (Input.GetMouseButtonDown(0) && timestampFiring <= Time.time)
                {
                    Fire();
                }
                else if (Input.GetMouseButtonDown(1) && timestampFiring <= Time.time)
                {
                    Fire();
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
            Shoot();

            particleSystem.Emit(fireParticleCount);

            AudioManager.instance.Play("RevolverShot");

            bulletsInMagazine--;
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

}
