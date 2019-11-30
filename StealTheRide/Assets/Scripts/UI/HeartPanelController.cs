using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class HeartPanelController : MonoBehaviour
{
    public PlayerStatistics player;
    public GameObject heartPrefab;
    public Sprite sHeartFull;
    public Sprite sHeartHalf;
    public Sprite sHeartEmpty;

    private List<GameObject> hearts;
    
    void Start()
    {
        hearts = new List<GameObject>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStatistics>();
        InitializeHearts();
    }

    public void UpdateHearts()
    {
        for (int i = 0; i < hearts.Count; i++)
        {
            int curr = (i + 1) * 2;
            int diff = curr - player.health;
            if (diff <= 0)
            {
                hearts[i].GetComponent<Image>().sprite = sHeartFull;
            } else if (diff == 1)
            {
                hearts[i].GetComponent<Image>().sprite = sHeartHalf;
            } else
            {
                hearts[i].GetComponent<Image>().sprite = sHeartEmpty;
            }
        }
    }

    private void InitializeHearts()
    {
        int heartCount = (player.maxHealth + 1) / 2;
        float heartWidth = heartPrefab.GetComponent<RectTransform>().rect.width;
        float spaceBetween = 10.0f;
        for (int i = 0; i < heartCount; i++)
        {
            GameObject h = GameObject.Instantiate(heartPrefab, Vector3.zero, Quaternion.identity);
            h.transform.SetParent(transform, false);
            h.transform.position = Vector2.zero;
            h.transform.localPosition = new Vector2(spaceBetween * (i + 1) + (i + 0.5f) * heartWidth, 0);
            hearts.Add(h);
        }
        UpdateHearts();
    }
}
