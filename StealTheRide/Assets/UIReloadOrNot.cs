﻿using UnityEngine;
using UnityEngine.UI;

public class UIReloadOrNot : MonoBehaviour
{
    public WeaponFire weapon;
    public Text text;

    void Update()
    {
        text.text = weapon.GetWeaponInfo();
    }
}

