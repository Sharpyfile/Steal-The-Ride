using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public GameObject revolver;
    public GameObject repeater;

    public static bool isRevolverActive = true;
    public static bool isRepeaterActive;

    void Start()
    {
        
    }
    
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            isRevolverActive = true;
            isRepeaterActive = false;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            isRevolverActive = false;
            isRepeaterActive = true;
        }

        if (isRevolverActive)
        {
            revolver.SetActive(true);
        }
        else
        {
            revolver.SetActive(false);
        }

        if (isRepeaterActive)
        {
            repeater.SetActive(true);
        }
        else
        {
            repeater.SetActive(false);
        }
    }
}
