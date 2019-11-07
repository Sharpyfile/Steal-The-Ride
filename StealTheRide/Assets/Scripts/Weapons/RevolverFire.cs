using UnityEngine;

public class RevolverFire : MonoBehaviour
{
    public bool isCocked = true;
    public static bool isSuperShot = false;
    public int magazineSize = 6;
    public int bulletsInMagazine = 6;
    public GameObject bullet;
    public GameObject reloadSlider;
    public PlayerStatistics player;
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

    void Awake()
    {
        Bullet.speed = 2.0f;
    }

    void Update()
    {
        Bullet.speed = 2.0f;

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

    private void StopReloading()
    {
        isReloading = false;
        reloadSlider.SetActive(false);
        weaponInfo = "Load next bullet";
    }
}
