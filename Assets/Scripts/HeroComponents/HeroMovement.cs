using UnityEngine;

namespace HeroComponents
{
    [RequireComponent(typeof(HeroInputReader))]
    public class HeroMovement : Movement
    {
        private HeroInputReader _inputReader;

        private void Awake() => 
            _inputReader = GetComponent<HeroInputReader>();

        private void OnEnable() => 
            _inputReader.DirectionChanged += SetDirection;

        private void OnDisable() => 
            _inputReader.DirectionChanged -= SetDirection;
    }
}