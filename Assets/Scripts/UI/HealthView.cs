using TMPro;
using UnityEngine;

namespace UI
{
    public class HealthView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _text;
        [SerializeField] private Health _health;

        private void OnEnable()
        {
            _health.HealthChanged += UpdateHealthText;
        }

        private void OnDisable()
        {
            _health.HealthChanged -= UpdateHealthText;
        }

        private void UpdateHealthText(int currentValue, int maxValue)
        {
            _text.text = $"{currentValue} / {maxValue}";
        }
    }
}