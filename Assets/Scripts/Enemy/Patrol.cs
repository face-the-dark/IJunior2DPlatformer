using System;
using System.Collections;
using UnityEngine;

namespace Enemy
{
    public class Patrol : MonoBehaviour
    {
        [SerializeField] private Transform _pointsParent;
        [SerializeField] private float _treshold = 1f;

        private Transform[] _points;
        private int _currentPointIndex = 0;
    
        public event Action<Vector2> DirectionChanged;

        private void Awake()
        {
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

                DirectionChanged?.Invoke(direction);

                yield return null;
            }
        }

        private bool InOnPoint() => 
            (_points[_currentPointIndex].position - transform.position).magnitude < _treshold;
    }
}