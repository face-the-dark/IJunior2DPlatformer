using UnityEngine;

namespace HeroComponents
{
    public class HeroAttacker : Attacker
    {
        [SerializeField] private HeroInputReader _inputReader;

        private void OnEnable() => 
            _inputReader.Attacked += Attack;

        private void OnDisable() => 
            _inputReader.Attacked -= Attack;
    }
}