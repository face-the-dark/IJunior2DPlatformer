using UnityEngine;

namespace Enemy
{
    [RequireComponent(typeof(Patrol))]
    public class EnemyMovement : Movement
    {
        private Patrol _patrol;
        private EnemyBrain _brain;

        protected void Awake()
        {
            _patrol = GetComponent<Patrol>();
            _brain = GetComponent<EnemyBrain>();
        }

        private void OnEnable()
        {
            _patrol.DirectionChanged += SetDirection;
            _brain.DirectionChangedToHero += SetDirection;
        }

        private void OnDisable()
        {
            _patrol.DirectionChanged -= SetDirection;
            _brain.DirectionChangedToHero -= SetDirection;
        }
    }
}