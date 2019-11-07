using UnityEngine;
using UnityEngine.UI;

public class UIReloadOrNot : MonoBehaviour
{
    public RevolverFire revolver;
    public RepeaterFire repeater;
    
    public Text text;

    void Update()
    {
        if (PlayerFire.isRevolverActive)
        {
            text.text = revolver.GetWeaponInfo();
        }
        else if (PlayerFire.isRepeaterActive)
        {
            text.text = repeater.GetWeaponInfo();
        }
    }
}

