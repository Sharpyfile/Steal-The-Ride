using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponsPanel : MonoBehaviour
{
    public List<WeaponFire> weapons;
    public RectTransform weaponsScrollView;
    public Transform scrollViewContent;
    public GameObject weaponInfoPanelPrefab;

    private Animator animator;
    private List<GameObject> panels;

    void Start()
    {
        animator = GetComponent<Animator>();
        panels = new List<GameObject>();
        Initialize();
    }
    
    void Update()
    {
        animator.SetBool("opened", Input.GetKey(KeyCode.Tab));
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
