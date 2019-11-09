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
                if (Input.GetMouseButtonDown(0) && timestampFiring <= Time.time)
                {
                    Fire();
                }
                if (Input.GetMouseButtonDown(1) && timestampFiring <= Time.time)
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
            GameObject.Instantiate(bullet, transform.position, transform.rotation).SetActive(true);
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
        }
    }

}
