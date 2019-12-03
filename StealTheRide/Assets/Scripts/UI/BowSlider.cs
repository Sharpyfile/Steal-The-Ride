using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BowSlider : MonoBehaviour
{
    private float speed;
    private Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = speed;
    }

    public void Set(float speed)
    {
        this.speed = speed;
    }
}
