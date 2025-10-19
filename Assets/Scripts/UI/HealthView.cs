using UnityEngine;

namespace UI
{
    public abstract class HealthView  : MonoBehaviour
    {
        [SerializeField] protected Health Health;

        private void OnEnable() => 
            Health.HealthChanged += UpdateHealthText;

        private void OnDisable() => 
            Health.HealthChanged -= UpdateHealthText;

        protected abstract void UpdateHealthText(int currentValue, int maxValue);
    }
}