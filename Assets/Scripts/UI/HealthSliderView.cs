using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class HealthSliderView : HealthView
    {
        [SerializeField] protected Slider Slider;

        protected override void UpdateView(int currentValue, int maxValue) => 
            Slider.value = CalculateCurrentPercentHealth(currentValue, maxValue);

        protected float CalculateCurrentPercentHealth(int currentValue, int maxValue) => 
            currentValue / (float)maxValue;
    }
}