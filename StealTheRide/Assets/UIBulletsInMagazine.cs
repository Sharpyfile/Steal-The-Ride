using UnityEngine;
using UnityEngine.UI;

public class UIBulletsInMagazine : MonoBehaviour
{
    public WeaponFire weapon;

    public Text text;

    void Update()
    {
        weapon = GameObject.FindObjectOfType<WeaponFire>();
        text.text = "Bullets in the magazine: \n" + weapon.bulletsInMagazine + "/" + weapon.magazineSize;
    }
}
