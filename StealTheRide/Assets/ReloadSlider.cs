using UnityEngine;
using UnityEngine.UI;

public class ReloadSlider : MonoBehaviour
{
    public float finishTime;
    public float timestampStart;

    private Slider slider;

    void Start()
    {
        slider = GetComponent<Slider>();
    }
    
    void Update()
    {
        slider.value = (Time.time - timestampStart) / finishTime * 100;
    }

    public void Set(float timestampStart, float finishTime)
    {
        this.timestampStart = timestampStart;
        this.finishTime = finishTime;
    }
}
