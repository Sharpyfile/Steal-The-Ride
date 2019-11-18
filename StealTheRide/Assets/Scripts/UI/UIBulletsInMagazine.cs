using UnityEngine;
using UnityEngine.UI;

public class UIBulletsInMagazine : MonoBehaviour
{
    public WeaponFire weapon;

    public Transform revolver1;
    public Transform revolver2;
    public Transform revolver3;
    public Transform revolver4;
    public Transform revolver5;
    public Transform revolver6;


    public Text text;

    void Update()
    {
        weapon = GameObject.FindObjectOfType<WeaponFire>();

        checkRemainingShots();
        text.text = "Bullets in the magazine: \n" + weapon.bulletsInMagazine + "/" + weapon.magazineSize;
    }

    void checkRemainingShots()
    {
        if(weapon.bulletsInMagazine > 0)
        {
            Debug.Log("elo");
            revolver1.GetComponent<Image>().enabled = true;
        }
        else
        {
            revolver1.GetComponent<Image>().enabled = false;
        }

        if (weapon.bulletsInMagazine > 1)
        {
            revolver2.GetComponent<Image>().enabled = true;
        }
        else
        {
            revolver2.GetComponent<Image>().enabled = false;
        }

        if (weapon.bulletsInMagazine > 2)
        {
            revolver3.GetComponent<Image>().enabled = true;
        }
        else
        {
            revolver3.GetComponent<Image>().enabled = false;
        }

        if (weapon.bulletsInMagazine > 3)
        {
            revolver4.GetComponent<Image>().enabled = true;
        }
        else
        {
            revolver4.GetComponent<Image>().enabled = false;
        }

        if (weapon.bulletsInMagazine > 4)
        {
            revolver5.GetComponent<Image>().enabled = true;
        }
        else
        {
            revolver5.GetComponent<Image>().enabled = false;
        }

        if (weapon.bulletsInMagazine > 5)
        {
            revolver6.GetComponent<Image>().enabled = true;
        }
        else
        {
            revolver6.GetComponent<Image>().enabled = false;
        }
    }
}
