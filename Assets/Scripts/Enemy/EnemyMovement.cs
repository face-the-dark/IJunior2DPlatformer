using UnityEngine;

namespace Enemy
{
    [RequireComponent(typeof(Patrol))]
    public class EnemyMovement : Movement
    {
        private Patrol _patrol;

        protected override void Awake()
        {
            base.Awake();

            _patrol = GetComponent<Patrol>();
        }

        private void OnEnable() => 
            _patrol.DirectionChanged += SetDirection;

        private void OnDisable() => 
            _patrol.DirectionChanged -= SetDirection;
    }
}