using UnityEngine;

namespace Enemy
{
    [RequireComponent(typeof(Patrol))]
    public class EnemyFlipper : Flipper
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
            _patrol.DirectionChanged += UpdateSpriteDirection;
            _brain.DirectionChangedToHero += UpdateSpriteDirection;
        }

        private void OnDisable()
        {
            _patrol.DirectionChanged -= UpdateSpriteDirection;
            _brain.DirectionChangedToHero -= UpdateSpriteDirection;
        }
    }
}