using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct LootWeapon
{
    public GameObject weapon;
}

public class WeaponSwitching : MonoBehaviour
{
    public LootWeapon[] lootTable;


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

    public int bulletsToPickUp;
    public int BulletsToPickUp
    {
        get { return bulletsToPickUp; }
        set { bulletsToPickUp = value; }
    }
    public int additionalBulletsToPickUp;
    public int AdditionalBulletsToPickUp
    {
        get { return additionalBulletsToPickUp; }
        set { additionalBulletsToPickUp = value; }
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
        if (PauseMenu.IsPaused)
            return;
        int previousSelectedWeapon = selectedWeapon;

        if (weaponToPickUp != -1 && Input.GetKeyDown(KeyCode.E))
        {
            ChangeWeapon();
        }



        if (Input.GetKeyDown(KeyCode.Alpha1))
            selectedWeapon = firstWeapon;

        if (Input.GetKeyDown(KeyCode.Alpha2))
            selectedWeapon = secondWeapon;

        if (previousSelectedWeapon != selectedWeapon)
        {
            if (weaponScript.isReloading == true)
            {
                weaponScript.StopReloading();
            }
            SelectWeapon();
        }
        
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

    private void ChangeWeapon()
    {
        if (selectedWeapon == firstWeapon)
        {
            selectedWeapon = weaponToPickUp;
        }
        DropWeapon(firstWeapon);
        firstWeapon = weaponToPickUp;
        SetNewWeapon(firstWeapon);
        weaponObjectToPickUp.Destroy();
    }

    private void DropWeapon(int lootWeapon)
    {
        GameObject newWeaponDrop = lootTable[lootWeapon].weapon;
        newWeaponDrop.GetComponent<WeaponLoot>().Bullets = transform.GetChild(lootWeapon).gameObject.GetComponent<WeaponFire>().BulletsInMagazine;
        newWeaponDrop.GetComponent<WeaponLoot>().AdditionalBullets = 0;

        Instantiate(newWeaponDrop, transform.position, Quaternion.identity);
    }

    private void SetNewWeapon(int newWeapon)
    {
        transform.GetChild(newWeapon).gameObject.GetComponent<WeaponFire>().BulletsInMagazine = bulletsToPickUp;
        transform.GetChild(newWeapon).gameObject.GetComponent<WeaponFire>().AdditionalBullets += additionalBulletsToPickUp;
    }
}
