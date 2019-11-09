using UnityEngine;
using UnityEngine.UI;

public class UIReloadOrNot : MonoBehaviour
{
    public WeaponFire weapon;
    
    public Text text;

    void Update()
    {
        weapon = GameObject.FindObjectOfType<WeaponFire>();
            //WeaponSwitching.sWeapon.WeaponFire;
        text.text = weapon.GetWeaponInfo();
    }
}

