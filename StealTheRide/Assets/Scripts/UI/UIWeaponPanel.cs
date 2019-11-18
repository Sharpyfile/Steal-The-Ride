using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIWeaponPanel : MonoBehaviour
{
    public Sprite revolver;
    public Sprite repeater;
    public Sprite shotgun;
    public Sprite bow;

    private WeaponSwitching weaponSwitching;
    private int selectedWeapon;

    void Start()
    {
        weaponSwitching = GameObject.FindObjectOfType<WeaponSwitching>();
    }

    void Update()
    {
        selectedWeapon = weaponSwitching.selectedWeapon;
        if (selectedWeapon == 0)
            GetComponent<Image>().sprite = revolver;
        if (selectedWeapon == 1)
            GetComponent<Image>().sprite = repeater;
        if (selectedWeapon == 2)
            GetComponent<Image>().sprite = shotgun;
        if (selectedWeapon == 3)
            GetComponent<Image>().sprite = bow;
    }
}
