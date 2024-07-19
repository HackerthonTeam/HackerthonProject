using UnityEngine;
using UnityEngine.UI;

public class sliderChange : MonoBehaviour
{
    [SerializeField]Slider slider;

    public void Start()
    {
        slider.onValueChanged.AddListener((float v)=>
        {
            OnSlider(v);
        });
    }

    public void OnSlider(float volume)
    {
        SoundManager.Instance.masterVol = volume;
    }
}
