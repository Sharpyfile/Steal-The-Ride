using UnityEngine;

public class RevolverFire : WeaponFire
{
    public bool isCocked = true;
    public static bool isSuperShot = false;

    private GameObject reloadSliderInstance;


    void Start()
    {
        timestampFiring = Time.time;
        timestampReload = Time.time;
    }

    void Awake()
    {
    }

    void Update()
    {
        if (!isReloading)
        {
            if (bulletsInMagazine > 0)
            {
                if (Input.GetMouseButton(0) && timestampFiring <= Time.time)
                {
                    if (Input.GetMouseButtonDown(1))
                    {
                        isSuperShot = true;
                        Fire();
                        isSuperShot = false;
                    } else if (Input.GetMouseButtonDown(0))
                    {
                        if (isCocked)
                        {
                            Fire();
                        }
                        else
                        {
                            AudioManager.instance.Play("RevolverEmptyChamber");
                            Debug.Log("You need to load the bullet in the chamber");
                        }
                    }
                    
                }
                else if (Input.GetMouseButtonDown(1))
                {
                    Pull();
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
            if (isSuperShot)
            {
                AudioManager.instance.Play("RevolverCock");
            }
            AudioManager.instance.Play("RevolverShot");
            bulletsInMagazine--;
            isCocked = false;
            Debug.Log("Firing");
            if (bulletsInMagazine > 0)
            {
                if (!isSuperShot)
                {
                    weaponInfo = "Load next bullet";
                }
                else
                {
                    weaponInfo = "SUPER FIRE!";
                }
            } else
            {
                weaponInfo = "No bullets!";
                Debug.Log("You have no bullets in magazine - reload");
            }
            timestampFiring = Time.time + fireCooldown;
        }
    }


    private void Pull()
    {
        if (isCocked == false)
        {
            isCocked = true;
            weaponInfo = "Ready to shoot";
            AudioManager.instance.Play("RevolverCock");
            Debug.Log("The gun has been reloaded");

        } else if (bulletsInMagazine > 0)
        {
            weaponInfo = "Ready to shoot";
            Debug.Log("There is already a bullet in the chamber!");
        }
    }

}
