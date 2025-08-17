using UnityEngine;

namespace HeroComponents
{
    [RequireComponent(typeof(HeroMover))]
    public class HeroFlipper : Flipper
    {
        private HeroMover _heroMover;

        private void Awake() => 
            _heroMover = GetComponent<HeroMover>();

        private void OnEnable() => 
            _heroMover.DirectionChanged += UpdateSpriteDirection;

        private void OnDisable() => 
            _heroMover.DirectionChanged -= UpdateSpriteDirection;
    }
}