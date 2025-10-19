using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class HealthSliderView : HealthView
    {
        [SerializeField] private Slider _slider;

        private void Start()
        {
            _slider.minValue = Health.MinValue;
            _slider.maxValue = Health.MaxValue;
        }

        protected override void UpdateHealthText(int currentValue, int maxValue) => 
            _slider.value = currentValue;
    }
}