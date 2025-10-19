using TMPro;
using UnityEngine;

namespace UI
{
    public class HealthTextView : HealthView
    {
        [SerializeField] private TextMeshProUGUI _text;
        
        protected override void UpdateHealthText(int currentValue, int maxValue) => 
            _text.text = $"{currentValue} / {maxValue}";
    }
}