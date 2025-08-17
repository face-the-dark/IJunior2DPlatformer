using UnityEngine;

namespace Enemy
{
    [RequireComponent(typeof(EnemyMover))]
    public class EnemyFlipper : Flipper
    {
        private EnemyMover _enemyMover;

        protected void Awake() => 
            _enemyMover = GetComponent<EnemyMover>();

        private void OnEnable() => 
            _enemyMover.DirectionChanged += UpdateSpriteDirection;

        private void OnDisable() => 
            _enemyMover.DirectionChanged -= UpdateSpriteDirection;
    }
}