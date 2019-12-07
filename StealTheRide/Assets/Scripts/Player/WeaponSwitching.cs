using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitching : MonoBehaviour
{
    public int selectedWeapon = 0;
    public WeaponFire weaponScript;

    //public WeaponFire firstWeapon;
    //public WeaponFire secondWeapon;
    public int firstWeapon = 1;

    public int secondWeapon = 0;

    public WeaponLoot weaponObjectToPickUp;
    public int weaponToPickUp = -1;
    public int WeaponToPickUp
    {
        get { return weaponToPickUp; }
        set { weaponToPickUp = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        SelectWeapon();
    }

    // Update is called once per frame
    //void Update()
    //{
    //    int previousSelectedWeapon = selectedWeapon;

    //    if (Input.GetKeyDown(KeyCode.Alpha1))
    //        selectedWeapon = 0;

    //    if (Input.GetKeyDown(KeyCode.Alpha2))
    //        selectedWeapon = 1;

    //    if (Input.GetKeyDown(KeyCode.Alpha3))
    //        selectedWeapon = 2;

    //    if (Input.GetKeyDown(KeyCode.Alpha4))
    //        selectedWeapon = 3;

    //    if (previousSelectedWeapon != selectedWeapon)
    //        SelectWeapon();
    //}

    void Update()
    {
        int previousSelectedWeapon = selectedWeapon;

        if (weaponToPickUp != -1 && Input.GetKeyDown(KeyCode.E))
        {
            if (selectedWeapon == firstWeapon)
            {
                selectedWeapon = weaponToPickUp;
            }
            firstWeapon = weaponToPickUp;
            weaponObjectToPickUp.Destroy();
        }



        if (Input.GetKeyDown(KeyCode.Alpha1))
            selectedWeapon = firstWeapon;

        if (Input.GetKeyDown(KeyCode.Alpha2))
            selectedWeapon = secondWeapon;

        if (previousSelectedWeapon != selectedWeapon)
            SelectWeapon();
    }

    void SelectWeapon ()
    {
        int i = 0;
        foreach (Transform weapon in transform)
        {
            if (i == selectedWeapon)
                weapon.gameObject.SetActive(true);
            else
                weapon.gameObject.SetActive(false);
            i++;
        }

        weaponScript = GameObject.FindObjectOfType<WeaponFire>();
        weaponScript.SetBullet();
    }
}
