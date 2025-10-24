using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int _maxValue = 10;

    private int _currentValue;
    public event Action<int, int> HealthChanged;
    public event Action DamageTaken;

    private void Awake() =>
        _currentValue = _maxValue;

    private void Start() =>
        HealthChanged?.Invoke(_currentValue, _maxValue);

    public void TakeDamage(int damage)
    {
        if (damage < 0)
            return;

        _currentValue = Mathf.Clamp(_currentValue - damage, 0, _maxValue);

        HealthChanged?.Invoke(_currentValue, _maxValue);
        DamageTaken?.Invoke();
    }

    public void HealItself(int healValue)
    {
        if (healValue < 0)
            return;

        _currentValue = Mathf.Clamp(_currentValue + healValue, 0, _maxValue);

        HealthChanged?.Invoke(_currentValue, _maxValue);
    }
}