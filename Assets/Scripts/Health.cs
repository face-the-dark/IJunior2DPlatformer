using System;
using Collecting;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int _maxHealth = 10;
    
    private int _currentHealth;

    public event Action DamageTaken;

    private void Awake() => 
        _currentHealth = _maxHealth;

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;

        if (_currentHealth <= 0) 
            _currentHealth = 0;
        
        DamageTaken?.Invoke();
    }

    public void Heal(HealPotion healPotion)
    {
        _currentHealth += healPotion.Value;
        
        if (_currentHealth > _maxHealth)
            _currentHealth = _maxHealth;
    }
}