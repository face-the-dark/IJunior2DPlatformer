using System;
using UnityEngine;

namespace EnemyComponents
{
    public class EnemyPatrol : MonoBehaviour
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

        public void DoPatrol()
        {
            if (IsOnPoint())
                _destinationPointIndex = (_destinationPointIndex + 1) % _waypoints.Length;

            Vector3 direction = (_waypoints[_destinationPointIndex].position - transform.position).normalized;
            direction.y = 0;

            DirectionChanged?.Invoke(direction);
        }

        private bool IsOnPoint() =>
            (_waypoints[_destinationPointIndex].position - transform.position).sqrMagnitude < _treshold;
    }
}