using System.Collections.Generic;
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
        Initialize();
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
            int sumOfBullets = weapons[i].bulletsInMagazine + weapons[i].additionalBullets;
            panels[i].GetComponentInChildren<Text>().text = weapons[i].bulletsInMagazine + "/" + sumOfBullets; ;
        }
    }

    private void Initialize()
    {
        for (int i = 0; i < weapons.Count; i++)
        {
            GameObject panel = GameObject.Instantiate(weaponInfoPanelPrefab, weaponInfoPanelPrefab.transform.position, Quaternion.identity);
            float sprHeightRatio = panel.GetComponentInChildren<Image>().rectTransform.rect.height / weapons[i].icon.bounds.size.y;//weapons[i].icon.rect.height;

            //Skomentowane do zwiększenia FPSów
            //Debug.Log(panel.GetComponentInChildren<Image>().rectTransform.rect.height);
            //Debug.Log(weapons[i].icon.rect.height);
            //Debug.Log(sprHeightRatio);

            panel.GetComponentInChildren<Image>().sprite = weapons[i].icon;
            panel.GetComponentInChildren<Image>().rectTransform.sizeDelta = new Vector2(weapons[i].icon.bounds.size.x * sprHeightRatio, panel.GetComponentInChildren<Image>().rectTransform.sizeDelta.y);
            //panel.GetComponent<Image>().SetNativeSize();
            panel.transform.SetParent(scrollViewContent, false);
            //DO POPRAWY SZTYWNIAK
            panel.GetComponent<RectTransform>().localPosition = new Vector2(0, 180 - i * weaponInfoPanelPrefab.GetComponent<RectTransform>().rect.height);
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
