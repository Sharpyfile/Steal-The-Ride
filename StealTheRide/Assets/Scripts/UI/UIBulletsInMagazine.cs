using UnityEngine;
using UnityEngine.UI;

public class UIBulletsInMagazine : MonoBehaviour
{
    public WeaponFire weapon;
    public int selectedWeapon = 0;

    public Transform revolver1;
    public Transform revolver2;
    public Transform revolver3;
    public Transform revolver4;
    public Transform revolver5;
    public Transform revolver6;

    public Transform repeater1;
    public Transform repeater2;
    public Transform repeater3;
    public Transform repeater4;
    public Transform repeater5;
    public Transform repeater6;
    public Transform repeater7;
    public Transform repeater8;
    public Transform repeater9;
    public Transform repeater10;
    public Transform repeater11;
    public Transform repeater12;
    public Transform repeater13;
    public Transform repeater14;
    public Transform repeater15;

    public Transform shotgun1;
    public Transform shotgun2;

    public Transform bow1;

    public Text text;

    void Start()
    {
        SelectWeapon();
    }

    void Update()
    {
        weapon = GameObject.FindObjectOfType<WeaponFire>();

        int previousSelectedWeapon = selectedWeapon;

        if (weapon == GameObject.FindObjectOfType<RevolverFire>())
            selectedWeapon = 0;

        if (weapon == GameObject.FindObjectOfType<RepeaterFire>())
            selectedWeapon = 1;

        if (weapon == GameObject.FindObjectOfType<ShotgunFire>())
            selectedWeapon = 2;

        if (weapon == GameObject.FindObjectOfType<BowFire>())
            selectedWeapon = 3;

        if (previousSelectedWeapon != selectedWeapon)
            SelectWeapon();

        if (selectedWeapon == 0)
            CheckRemainingRevolverShots();
        if (selectedWeapon == 1)
            CheckRemainingRepeaterShots();
        if (selectedWeapon == 2)
            CheckRemainingShotgunShots();
        if (selectedWeapon == 3)
            CheckRemainingBowShots();

        if (selectedWeapon == 3)
            text.text = ""; // "Arrows: \n" + weapon.bulletsInMagazine;
        else
            text.text = "Bullets in the magazine: \n" + weapon.bulletsInMagazine + "/" + weapon.magazineSize;
    }

    void SelectWeapon()
    {
        int i = 0;
        foreach (Transform weaponAmmo in transform)
        {
            if (i == selectedWeapon)
                weaponAmmo.gameObject.SetActive(true);
            else
                weaponAmmo.gameObject.SetActive(false);
            i++;
        }

    }

    void CheckRemainingRevolverShots()
    {
        if(weapon.bulletsInMagazine > 0)
        {
            revolver1.GetComponent<Image>().color = Color.white;
        }
        else
        {
            revolver1.GetComponent<Image>().color = Color.grey;
        }

        if (weapon.bulletsInMagazine > 1)
        {
            revolver2.GetComponent<Image>().color = Color.white;
        }
        else
        {
            revolver2.GetComponent<Image>().color = Color.grey;
        }

        if (weapon.bulletsInMagazine > 2)
        {
            revolver3.GetComponent<Image>().color = Color.white;
        }
        else
        {
            revolver3.GetComponent<Image>().color = Color.grey;
        }

        if (weapon.bulletsInMagazine > 3)
        {
            revolver4.GetComponent<Image>().color = Color.white;
        }
        else
        {
            revolver4.GetComponent<Image>().color = Color.grey;
        }

        if (weapon.bulletsInMagazine > 4)
        {
            revolver5.GetComponent<Image>().color = Color.white;
        }
        else
        {
            revolver5.GetComponent<Image>().color = Color.grey;
        }

        if (weapon.bulletsInMagazine > 5)
        {
            revolver6.GetComponent<Image>().color = Color.white;
        }
        else
        {
            revolver6.GetComponent<Image>().color = Color.grey;
        }
    }

    void CheckRemainingRepeaterShots()
    {
        if (weapon.bulletsInMagazine > 0)
        {
            repeater1.GetComponent<Image>().color = Color.white;
        }
        else
        {
            repeater1.GetComponent<Image>().color = Color.grey;
        }

        if (weapon.bulletsInMagazine > 1)
        {
            repeater2.GetComponent<Image>().color = Color.white;
        }
        else
        {
            repeater2.GetComponent<Image>().color = Color.grey;
        }

        if (weapon.bulletsInMagazine > 2)
        {
            repeater3.GetComponent<Image>().color = Color.white;
        }
        else
        {
            repeater3.GetComponent<Image>().color = Color.grey;
        }

        if (weapon.bulletsInMagazine > 3)
        {
            repeater4.GetComponent<Image>().color = Color.white;
        }
        else
        {
            repeater4.GetComponent<Image>().color = Color.grey;
        }

        if (weapon.bulletsInMagazine > 4)
        {
            repeater5.GetComponent<Image>().color = Color.white;
        }
        else
        {
            repeater5.GetComponent<Image>().color = Color.grey;
        }

        if (weapon.bulletsInMagazine > 5)
        {
            repeater6.GetComponent<Image>().color = Color.white;
        }
        else
        {
            repeater6.GetComponent<Image>().color = Color.grey;
        }

        if (weapon.bulletsInMagazine > 6)
        {
            repeater7.GetComponent<Image>().color = Color.white;
        }
        else
        {
            repeater7.GetComponent<Image>().color = Color.grey;
        }

        if (weapon.bulletsInMagazine > 7)
        {
            repeater8.GetComponent<Image>().color = Color.white;
        }
        else
        {
            repeater8.GetComponent<Image>().color = Color.grey;
        }

        if (weapon.bulletsInMagazine > 8)
        {
            repeater9.GetComponent<Image>().color = Color.white;
        }
        else
        {
            repeater9.GetComponent<Image>().color = Color.grey;
        }

        if (weapon.bulletsInMagazine > 9)
        {
            repeater10.GetComponent<Image>().color = Color.white;
        }
        else
        {
            repeater10.GetComponent<Image>().color = Color.grey;
        }

        if (weapon.bulletsInMagazine > 10)
        {
            repeater11.GetComponent<Image>().color = Color.white;
        }
        else
        {
            repeater11.GetComponent<Image>().color = Color.grey;
        }

        if (weapon.bulletsInMagazine > 11)
        {
            repeater12.GetComponent<Image>().color = Color.white;
        }
        else
        {
            repeater12.GetComponent<Image>().color = Color.grey;
        }

        if (weapon.bulletsInMagazine > 12)
        {
            repeater13.GetComponent<Image>().color = Color.white;
        }
        else
        {
            repeater13.GetComponent<Image>().color = Color.grey;
        }

        if (weapon.bulletsInMagazine > 13)
        {
            repeater14.GetComponent<Image>().color = Color.white;
        }
        else
        {
            repeater14.GetComponent<Image>().color = Color.grey;
        }

        if (weapon.bulletsInMagazine > 14)
        {
            repeater15.GetComponent<Image>().color = Color.white;
        }
        else
        {
            repeater15.GetComponent<Image>().color = Color.grey;
        }
    }

    void CheckRemainingShotgunShots()
    {
        if (weapon.isLeftChamberFull == true)
        {
            shotgun1.GetComponent<Image>().color = Color.white;
        }
        else
        {
            shotgun1.GetComponent<Image>().color = Color.grey;
        }

        if (weapon.isRightChamberFull == true)
        {
            shotgun2.GetComponent<Image>().color = Color.white;
        }
        else
        {
            shotgun2.GetComponent<Image>().color = Color.grey;
        }
    }

    void CheckRemainingBowShots()
    {
        if (weapon.bulletsInMagazine > 0)
        {
            bow1.GetComponent<Image>().color = Color.white;
        }
        else
        {
            bow1.GetComponent<Image>().color = Color.grey;
        }
    }
}
