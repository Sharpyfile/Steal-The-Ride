using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIWeaponPanel : MonoBehaviour
{
    public Sprite revolver;
    public Sprite revolverCocked;
    public Sprite revolverReloading;
    public Sprite repeater;
    public Sprite repeaterPush;
    public Sprite repeaterPull;
    public Sprite repeaterReloading;
    public Sprite shotgun;
    public Sprite shotgunLeft;
    public Sprite shotgunRight;
    public Sprite shotgunReloading;
    public Sprite bow;

    public WeaponSwitching weaponSwitching;
    public RevolverFire revolverFire;
    public RepeaterFire repeaterFire;
    public ShotgunFire shotgunFire;
    public BowFire bowFire;
    private int selectedWeapon;
    private bool isCocked;
    private int revolverBulletsInMagazine;
    private int repeaterBulletsInMagazine;
    private int shotgunBulletsInMagazine;
    private int bowBulletsInMagazine;
    private bool isLeverForward;
    private bool isLeverBackward;
    private bool isLeftChamberFull;
    private bool isRightChamberFull;

    void Start()
    {
        weaponSwitching = GameObject.FindObjectOfType<WeaponSwitching>();
        //revolverFire = GameObject.FindObjectOfType<RevolverFire>();
        //repeaterFire = GameObject.FindObjectOfType<RepeaterFire>();
        //shotgunFire = GameObject.FindObjectOfType<ShotgunFire>();
        //bowFire = GameObject.FindObjectOfType<BowFire>();
    }

    void Update()
    {
        selectedWeapon = weaponSwitching.selectedWeapon;
        isCocked = revolverFire.isCocked;
        isLeverForward = repeaterFire.isLeverForward;
        isLeverBackward = repeaterFire.isLeverBackward;
        revolverBulletsInMagazine = revolverFire.bulletsInMagazine;
        repeaterBulletsInMagazine = repeaterFire.bulletsInMagazine;
        shotgunBulletsInMagazine = shotgunFire.bulletsInMagazine;
        bowBulletsInMagazine = bowFire.bulletsInMagazine;

        //revolver
        if (selectedWeapon == 0)
        {
            GetComponent<Image>().rectTransform.sizeDelta = new Vector2(520.0f, 200.0f);
            GetComponent<Image>().sprite = revolver;
            if (isCocked == false)
            {
                GetComponent<Image>().rectTransform.sizeDelta = new Vector2(500.0f, 350.0f);
                GetComponent<Image>().sprite = revolverCocked;
            }
            if (revolverBulletsInMagazine == 0)
            {
                GetComponent<Image>().rectTransform.sizeDelta = new Vector2(520.0f, 200.0f);
                GetComponent<Image>().sprite = revolverReloading;
            }
        }
        //repeater
        if (selectedWeapon == 1)
        {
            GetComponent<Image>().rectTransform.sizeDelta = new Vector2(520.0f, 200.0f);
            GetComponent<Image>().sprite = repeater;
            if (isLeverBackward == false && isLeverForward == false)
            {
                GetComponent<Image>().rectTransform.sizeDelta = new Vector2(500.0f, 350.0f);
                GetComponent<Image>().sprite = repeaterPush;
            }
            if (isLeverBackward == false && isLeverForward == true)
            {
                GetComponent<Image>().rectTransform.sizeDelta = new Vector2(500.0f, 350.0f);
                GetComponent<Image>().sprite = repeaterPull;
            }
            if (isLeverBackward == true && isLeverForward == true)
            {
                GetComponent<Image>().rectTransform.sizeDelta = new Vector2(520.0f, 200.0f);
                GetComponent<Image>().sprite = repeater;
            }
            if (repeaterBulletsInMagazine == 0)
            {
                GetComponent<Image>().rectTransform.sizeDelta = new Vector2(520.0f, 200.0f);
                GetComponent<Image>().sprite = repeaterReloading;
            }
        }
        //shotgun
        if (selectedWeapon == 2)
        {
            GetComponent<Image>().rectTransform.sizeDelta = new Vector2(520.0f, 200.0f);
            GetComponent<Image>().sprite = shotgun;
            if (isLeftChamberFull == false && isRightChamberFull == true)
            {
                GetComponent<Image>().rectTransform.sizeDelta = new Vector2(520.0f, 200.0f);
                GetComponent<Image>().sprite = shotgunLeft;
            }
            if (isLeftChamberFull == true && isRightChamberFull == false)
            {
                GetComponent<Image>().rectTransform.sizeDelta = new Vector2(520.0f, 200.0f);
                GetComponent<Image>().sprite = shotgunRight;
            }
            if (isLeftChamberFull == true && isRightChamberFull == true)
            {
                GetComponent<Image>().rectTransform.sizeDelta = new Vector2(520.0f, 200.0f);
                GetComponent<Image>().sprite = shotgun;
            }
            if (shotgunBulletsInMagazine == 0)
            {
                GetComponent<Image>().rectTransform.sizeDelta = new Vector2(520.0f, 200.0f);
                GetComponent<Image>().sprite = shotgunReloading;
            }
        }
        //bow
        if (selectedWeapon == 3)
        {
            GetComponent<Image>().sprite = bow;
        }
    }
}

