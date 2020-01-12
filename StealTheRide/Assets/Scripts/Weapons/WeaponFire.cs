using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponFire : MonoBehaviour
{
    public string weaponInfo;
    public int magazineSize;

    public int bulletsInMagazine;
    public int BulletsInMagazine
    {
        get { return bulletsInMagazine; }
        set { bulletsInMagazine = value; }
    }

    public int additionalBullets;
    public int AdditionalBullets
    {
        get { return additionalBullets; }
        set { additionalBullets = value; }
    }
    public int sumOfBullets;

    public GameObject bullet;
    public Transform firePoint;
    public GameObject reloadSlider;
    public PlayerStatistics player;
    public float reloadTime;
    public float fireCooldown;

    public float timestampFiring;
    public float timestampReload;
    public bool isReloading = false;

    public float speed;
    public float damage;
    public float spreadFactor;
    public Bullet bulletScript;
    public Sprite icon;

    public bool isLeftChamberFull;
    public bool isRightChamberFull;

    public string GetWeaponInfo()
    {
        return weaponInfo;
    }
    public void SetBullet()
    {
        bulletScript.Damage = damage;
    }

    public virtual void Shoot()
    {
        GameObject newBullet = GameObject.Instantiate(bullet, firePoint.position, firePoint.rotation);
        newBullet.SetActive(true);
        Rigidbody2D rb = newBullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.right * speed, ForceMode2D.Impulse);
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
                weaponInfo = "Reloading...";
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
        bulletsInMagazine++;
        additionalBullets--;
        AudioManager.instance.Play("RevolverReloadTick");
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

    public abstract void StopReloading();
    //{
    //    isReloading = false;
    //    reloadSlider.SetActive(false);
    //    weaponInfo = "";
    //}

}
