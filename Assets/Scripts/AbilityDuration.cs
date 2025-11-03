using System;
using System.Collections;
using UnityEngine;

public class AbilityDuration : MonoBehaviour
{
    [SerializeField] private float _value;

    private float _currentValue;
    private Coroutine _coroutine;
    
    public float CurrentValue => Mathf.CeilToInt(_currentValue);
    
    public event Action Began;
    
    private void Start() => 
        Reset();

    public void Begin()
    {
        Reset();
        StopCoroutine();

        _coroutine = StartCoroutine(WasteTime());
        
        Began?.Invoke();
    }

    public bool IsEnd() =>
        _currentValue <= 0;

    private void Reset() =>
        _currentValue = _value;

    private void StopCoroutine()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
            _coroutine = null;
        }
    }

    private IEnumerator WasteTime()
    {
        while (IsEnd() == false)
        {
            _currentValue -= Time.deltaTime;

            yield return null;
        }
    }
}