using UnityEngine.UI;
using UnityEngine;
using Shamrock;

public class SliderController : MonoBehaviour {

    public Slider slider;

    [SerializeField]
    FloatVariable sliderValue;

    public void OnValueChanged()
    {
        sliderValue.Value = slider.value;
    }
}
