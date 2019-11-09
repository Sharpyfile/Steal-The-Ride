using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponFire : MonoBehaviour
{
    public string weaponInfo;
    public int magazineSize;
    public int bulletsInMagazine;

    public GameObject bullet;
    public GameObject reloadSlider;
    public PlayerStatistics player;
    public float reloadTime;
    public float fireCooldown;

    public float timestampFiring;
    public float timestampReload;
    public bool isReloading = false;

    public float speed;
    public int damage;
    public float spreadFactor;
    public Bullet bulletScript;

    public string GetWeaponInfo()
    {
        return weaponInfo;
    }
    public void SetBullet()
    {
        bulletScript.Speed = speed;
        bulletScript.Damage = damage;
        bulletScript.SpreadFactor = spreadFactor;
    }

    public void Reload()
    {
        if (!isReloading)
        {
            if (bulletsInMagazine < magazineSize)
            {
                isReloading = true;
                timestampReload = Time.time + reloadTime;
                reloadSlider.GetComponent<ReloadSlider>().Set(Time.time, (magazineSize - bulletsInMagazine) * reloadTime);
                reloadSlider.SetActive(true);
            }
        }
        else
        {
            StopReloading();
        }
    }

    public void ReloadTick()
    {
        Debug.Log("Loading bullet...");
        weaponInfo = "Reloading...";
        bulletsInMagazine++;
        AudioManager.instance.Play("RevolverReloadTick");
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

    public void StopReloading()
    {
        isReloading = false;
        reloadSlider.SetActive(false);
        weaponInfo = "";
    }

}
