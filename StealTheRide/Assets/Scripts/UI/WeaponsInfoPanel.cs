﻿using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class WeaponsInfoPanel : MonoBehaviour
{
    public List<WeaponFire> weapons;
    public RectTransform weaponsScrollView;
    public Transform scrollViewContent;
    public GameObject weaponInfoPanelPrefab;
    public float slideSpeed = 0.5f;
    
    private List<GameObject> panels;
    private float middleWidth;
    private Tween currentTween;

    void Start()
    {
        panels = new List<GameObject>();
        middleWidth = GetComponent<RectTransform>().rect.width / 2.0f;
        //Initialize();
    }
    
    void Update()
    {
        //animator.SetBool("opened", Input.GetKey(KeyCode.Tab));
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            Show();
        }
        if (Input.GetKeyUp(KeyCode.Tab))
        {
            Hide();
        }
        
        for (int i = 0; i < panels.Count; i++)
        {
            panels[i].GetComponentInChildren<Text>().text = weapons[i].bulletsInMagazine + "/" + weapons[i].magazineSize;
        }
    }

    private void Initialize()
    {
        for (int i = 0; i < weapons.Count; i++)
        {
            GameObject panel = GameObject.Instantiate(weaponInfoPanelPrefab, weaponInfoPanelPrefab.transform.position, Quaternion.identity);
            panel.transform.SetParent(scrollViewContent, false);
            //DO POPRAWY SZTYWNIAK
            panel.GetComponent<RectTransform>().localPosition = new Vector2(0, 100 - i * weaponInfoPanelPrefab.GetComponent<RectTransform>().rect.height);
            panels.Add(panel);
        }
    }

    private void Show()
    {
        //LeanTween.cancel(gameObject);
        //rt.localPosition = offScreenLeftPosition;
        currentTween.Kill();
        currentTween = GetComponent<RectTransform>().DOAnchorPosX(middleWidth, slideSpeed);//.SetEase(Ease.InOutExpo);
        //LeanTween.move(rt, centerPosition, 0.3f).setEase(LeanTweenType.easeInOutExpo);
    }

    private void Hide()
    {
        //LeanTween.cancel(gameObject);
        currentTween.Kill();
        currentTween = GetComponent<RectTransform>().DOAnchorPosX(-middleWidth, slideSpeed);//.SetEase(Ease.InOutExpo);
    }
}
