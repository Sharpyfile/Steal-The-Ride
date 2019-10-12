using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponFire : MonoBehaviour
{
    private bool isReloaded = true;
    public int magazine = 6;
    public int bulletsInMagazine = 6;
    public GameObject bullet;

   

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (bulletsInMagazine > 0)
            {
                if (isReloaded)
                {
                    GameObject.Instantiate(bullet, this.transform.position, this.transform.rotation).SetActive(true);

                    bulletsInMagazine--;
                    isReloaded = false;
                    Debug.Log("Firing");
                }

                else
                    Debug.Log("You need to load the bullet in the chamber");
                
            }
            else
                Debug.Log("You have no bullets in magazine - reload");

        }

        if (Input.GetMouseButtonDown(1))
        {
            if (isReloaded == false)
            {
                isReloaded = true;
                Debug.Log("The gun has been reloaded");
            }
                
            else
            {
                Debug.Log("There is already a bullet in the chamber - ejecting shell");
                bulletsInMagazine--;
            }
                
        }

        if (Input.GetButtonDown("Reload"))
        {
            bulletsInMagazine = magazine;
            isReloaded = true;
            Debug.Log("Reloading");
        }

    }
}
