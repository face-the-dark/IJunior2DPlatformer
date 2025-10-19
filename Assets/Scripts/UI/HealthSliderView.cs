using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class HealthSliderView : HealthView
    {
        [SerializeField] protected Slider Slider;

        private void Start()
        {
            Slider.minValue = Health.MinValue;
            Slider.maxValue = Health.MaxValue;
        }

        protected override void UpdateView(int currentValue, int maxValue) => 
            Slider.value = currentValue;
    }
}