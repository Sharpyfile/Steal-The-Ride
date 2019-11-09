using UnityEngine;

public class PSFollowWeapon : MonoBehaviour
{
    public Transform weapon;
    
    void Update()
    {
        transform.rotation = weapon.rotation;

    }
}
