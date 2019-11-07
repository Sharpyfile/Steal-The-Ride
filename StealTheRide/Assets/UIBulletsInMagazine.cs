using UnityEngine;
using UnityEngine.UI;

public class UIBulletsInMagazine : MonoBehaviour
{
    public RevolverFire revolver;
    public RepeaterFire repeater;

    public Text text;

    void Update()
    {
        if(PlayerFire.isRevolverActive)
        {
            text.text = "Bullets in the magazine: \n" + revolver.bulletsInMagazine + "/" + revolver.magazineSize;
        }
        else if (PlayerFire.isRepeaterActive)
        {
            text.text = "Bullets in the magazine: \n" + repeater.bulletsInMagazine + "/" + repeater.magazineSize;
        }
    }
}
