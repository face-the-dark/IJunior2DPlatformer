using TMPro;
using UnityEngine;

namespace UI
{
    public class HealthTextView : HealthView
    {
        [SerializeField] private TextMeshProUGUI _text;
        
        protected override void UpdateView(int currentValue, int maxValue) => 
            _text.text = $"{currentValue} / {maxValue}";
    }
}