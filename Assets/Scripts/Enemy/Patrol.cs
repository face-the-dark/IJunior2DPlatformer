using System;
using System.Collections;
using UnityEngine;

namespace Enemy
{
    public class Patrol : MonoBehaviour
    {
        [SerializeField] private Transform _waypointsContainer;
        [SerializeField] private float _treshold = 1f;

        private Transform[] _waypoints;
        private int _destinationPointIndex;
    
        public event Action<Vector2> DirectionChanged;

        private void Awake()
        {
            _waypoints = _waypointsContainer.GetComponentsInChildren<Transform>();
            _destinationPointIndex = 0;
        }

        public IEnumerator DoPatrol()
        {
            while (enabled)
            {
                if (InOnPoint()) 
                    _destinationPointIndex = (_destinationPointIndex + 1) % _waypoints.Length;
            
                Vector3 direction = (_waypoints[_destinationPointIndex].position - transform.position).normalized;
                direction.y = 0;

                DirectionChanged?.Invoke(direction);

                yield return null;
            }
        }

        private bool InOnPoint() => 
            (_waypoints[_destinationPointIndex].position - transform.position).sqrMagnitude < _treshold;
    }
}