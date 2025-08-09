using UnityEngine;

namespace Enemy
{
    [RequireComponent(typeof(Patrol))]
    public class EnemyFlipper : Flipper
    {
        private Patrol _patrol;

        protected void Awake() => 
            _patrol = GetComponent<Patrol>();

        private void OnEnable() => 
            _patrol.DirectionChanged += UpdateSpriteDirection;

        private void OnDisable() => 
            _patrol.DirectionChanged -= UpdateSpriteDirection;
    }
}