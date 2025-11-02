using Abilities.Vampirism;
using UnityEngine;

namespace HeroComponents
{
    public class HeroVampirismAbility : VampirismAbility
    {
        [SerializeField] private HeroInputReader _inputReader;

        private void OnEnable() => 
            _inputReader.Vampirized += EnableVampirism;

        private void OnDisable() => 
            _inputReader.Vampirized -= EnableVampirism;
    }
}