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
    
    private List<GameObject> panels;

    void Start()
    {
        panels = new List<GameObject>();
        //GetComponent<RectTransform>().DOMoveX(0.0f, 1.0f);
        //DOTween.Play();
        //Initialize();
    }
    
    void Update()
    {
        //animator.SetBool("opened", Input.GetKey(KeyCode.Tab));
        
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
}
