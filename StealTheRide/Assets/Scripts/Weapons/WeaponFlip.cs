using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponFlip : MonoBehaviour
{
    private SpriteRenderer weaponSprite;

    private void Start()
    {
        weaponSprite = GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.rotation.eulerAngles.z >= 90 && transform.rotation.eulerAngles.z <= 270)
            weaponSprite.flipY = true;
        else
            weaponSprite.flipY = false;

    }
}
