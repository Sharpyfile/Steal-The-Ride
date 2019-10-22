using UnityEngine;

public class WeaponFire : MonoBehaviour
{
    public bool isCocked = true;
    public static bool isSuperShot = false;
    public int magazineSize = 6;
    public int bulletsInMagazine = 6;
    public GameObject bullet;
    public GameObject reloadSlider;
    public float reloadTime = 1;
    public float fireCooldown;

    private string weaponInfo;
    private float timestampFiring;
    private float timestampReload;
    private bool isReloading = false;
    private GameObject reloadSliderInstance;

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
        if (!isReloading)
        {
            if (bulletsInMagazine > 0)
            {
                if (Input.GetMouseButton(0) && timestampFiring <= Time.time)
                {
                    if (isCocked)
                    {
                        Fire();
                        weaponInfo = "Load next bullet";
                    }
                    else if (Input.GetMouseButtonDown(1))
                    {
                        isSuperShot = true;
                        Fire();
                        weaponInfo = "SUPER FIRE!";
                        isSuperShot = false;
                    }
                    else
                    {
                        Debug.Log("You need to load the bullet in the chamber");
                    }
                }
                else if (Input.GetMouseButtonDown(1))
                {
                    Pull();
                }
            }
            else
            {
                weaponInfo = "No bullets!";
                Debug.Log("You have no bullets in magazine - reload");
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
        
            GameObject.Instantiate(bullet, transform.position, transform.rotation).SetActive(true);

            bulletsInMagazine--;
            isCocked = false;
            Debug.Log("Firing");
            //weaponInfo = "Load next bullet";
            timestampFiring = Time.time + fireCooldown;

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

    private void ReloadTick()
    {
        Debug.Log("Loading bullet...");
        weaponInfo = "Reloading...";
        bulletsInMagazine++;
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

    private void StopReloading()
    {
        isReloading = false;
        reloadSlider.SetActive(false);
        weaponInfo = "Load next bullet";
    }
}
