using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int _maxValue = 10;
    
    private int _currentValue;

    public event Action DamageTaken;

    private void Awake() => 
        _currentValue = _maxValue;

    public void TakeDamage(int damage)
    {
        _currentValue -= damage;

        if (_currentValue <= 0) 
            _currentValue = 0;
        
        DamageTaken?.Invoke();
    }

    public void HealItself(int healValue)
    {
        _currentValue += healValue;
        
        if (_currentValue > _maxValue)
            _currentValue = _maxValue;
    }
}