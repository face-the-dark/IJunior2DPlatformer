using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int _maxValue = 10;
    
    private int _currentValue;

    public event Action DamageTaken;
    public event Action<int, int> HealthChanged;

    private void Awake() => 
        _currentValue = _maxValue;

    private void Start() => 
        HealthChanged?.Invoke(_currentValue, _maxValue);

    public void TakeDamage(int damage)
    {
        _currentValue -= damage;

        if (_currentValue <= 0) 
            _currentValue = 0;
        
        DamageTaken?.Invoke();
        HealthChanged?.Invoke(_currentValue, _maxValue);
    }

    public void HealItself(int healValue)
    {
        _currentValue += healValue;
        
        if (_currentValue > _maxValue)
            _currentValue = _maxValue;
        
        HealthChanged?.Invoke(_currentValue, _maxValue);
    }
}