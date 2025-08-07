using System.Collections;
using UnityEngine;

[RequireComponent(typeof(HeroMovement))]
[RequireComponent(typeof(HeroAnimator))]
public class Patrol : MonoBehaviour
{
    [SerializeField] private Transform _pointsParent;
    [SerializeField] private float _treshold = 1f;
    
    private HeroMovement _movement;
    private HeroAnimator _animator;

    private Transform[] _points;
    private int _currentPointIndex = 0;

    private void Awake()
    {
        _movement = GetComponent<HeroMovement>();
        _animator = GetComponent<HeroAnimator>();
        
        _points = _pointsParent.GetComponentsInChildren<Transform>();
        
        StartCoroutine(DoPatrol());
    }

    private IEnumerator DoPatrol()
    {
        while (enabled)
        {
            if (InOnPoint()) 
                _currentPointIndex = (_currentPointIndex + 1) % _points.Length;
            
            Vector3 direction = _points[_currentPointIndex].position - transform.position;
            
            direction.y = 0;
            direction.Normalize();

            _movement.SetDirection(direction);
            _animator.SetDirection(direction);

            yield return null;
        }
    }

    private bool InOnPoint() => 
        (_points[_currentPointIndex].position - transform.position).magnitude < _treshold;
}