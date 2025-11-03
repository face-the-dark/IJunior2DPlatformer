using System;
using UnityEngine;

public class Cooldown : MonoBehaviour
{
    [SerializeField] private float _value = 1f;

    private float _delta;
    private bool _isInReset;
    
    public float Delta => Mathf.CeilToInt(_delta);
    public float CurrentValue => _delta / _value;
    public bool IsInReset => _isInReset;
    
    public event Action InReset;
    public event Action Expired;
    
    private void Awake() =>
        _delta = 0;

    private void Update()
    {
        if (_isInReset)
            _delta -= Time.deltaTime;

        if (IsExpired())
        {
            _isInReset = false;
            
            Expired?.Invoke();
        }
    }

    public void Reset()
    {
        _isInReset = true;
        _delta = _value;
        
        InReset?.Invoke();
    }

    public bool IsExpired() =>
        _delta <= 0;
}