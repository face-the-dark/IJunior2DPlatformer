using UnityEngine;

namespace Hero
{
    [RequireComponent(typeof(HeroInputReader))]
    public class HeroFlipper : Flipper
    {
        private HeroInputReader _inputReader;

        private void Awake() => 
            _inputReader = GetComponent<HeroInputReader>();

        private void OnEnable() => 
            _inputReader.DirectionChanged += UpdateSpriteDirection;

        private void OnDisable() => 
            _inputReader.DirectionChanged -= UpdateSpriteDirection;
    }
}