using UnityEngine;

namespace HeroComponents
{
    [RequireComponent(typeof(HeroInputReader))]
    public class HeroAttacker : Attacker
    {
        private HeroInputReader _inputReader;

        private void Awake() => 
            _inputReader = GetComponent<HeroInputReader>();

        private void OnEnable() => 
            _inputReader.Attacked += DealDamage;

        private void OnDisable() => 
            _inputReader.Attacked -= DealDamage;
    }
}