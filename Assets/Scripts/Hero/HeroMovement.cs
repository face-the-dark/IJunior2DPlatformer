using UnityEngine;

namespace Hero
{
    [RequireComponent(typeof(HeroInputReader))]
    public class HeroMovement : Movement
    {
        private HeroInputReader _inputReader;

        protected override void Awake()
        {
            base.Awake();
        
            _inputReader = GetComponent<HeroInputReader>();
        }

        private void OnEnable() => 
            _inputReader.DirectionChanged += SetDirection;

        private void OnDisable() => 
            _inputReader.DirectionChanged -= SetDirection;
    }
}