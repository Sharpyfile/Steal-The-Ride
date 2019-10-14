using UnityEngine;

public class WeaponFire : MonoBehaviour
{
    public bool isCocked = true;
    public int magazine = 6;
    public int bulletsInMagazine = 6;
    public GameObject bullet;
    public float reloadCooldown;
    public float fireCooldown;

    private string weaponInfo;
    private float timestampFiring;
    private float timestampReload;

    public string GetWeaponInfo()
    {
        return weaponInfo;
    }

    void Start()
    {
        timestampFiring = Time.time;
        timestampReload = Time.time;
    }

    void Update()
    {
        if (bulletsInMagazine > 0)
        {
            if (Input.GetMouseButtonDown(0) && timestampFiring <= Time.time)
            {
                Fire();
            } else if (Input.GetMouseButtonDown(1))
            {
                Pull();
            }
        } else
        {
            Debug.Log("You have no bullets in magazine - reload");
        }

        if (Input.GetButtonDown("Reload") && timestampReload <= Time.time)
        {
            Reload();
        }

    }

    private void Fire()
    {
        if (isCocked)
        {
            GameObject.Instantiate(bullet, transform.position, transform.rotation).SetActive(true);

            bulletsInMagazine--;
            isCocked = false;
            Debug.Log("Firing");
            weaponInfo = "Load next bullet";
            timestampFiring = Time.time + fireCooldown;
        } else
        {
            Debug.Log("You need to load the bullet in the chamber");
        }
    }

    private void Pull()
    {
        if (isCocked == false)
        {
            isCocked = true;
            weaponInfo = "Ready to shoot";
            Debug.Log("The gun has been reloaded");

        } else if (bulletsInMagazine > 0)
        {
            weaponInfo = "Ready to shoot";
            Debug.Log("There is already a bullet in the chamber!");
        }
    }

    private void Reload()
    {
        bulletsInMagazine = magazine;
        isCocked = true;
        timestampReload = Time.time + reloadCooldown;
        timestampFiring = Time.time + reloadCooldown;
        weaponInfo = "Reloaded \nready to Shoot";
        Debug.Log("Reloading");
    }
}
