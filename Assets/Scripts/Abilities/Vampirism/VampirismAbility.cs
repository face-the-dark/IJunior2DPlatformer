using System;
using System.Collections;
using UnityEngine;

namespace Abilities.Vampirism
{
    [RequireComponent(typeof(Cooldown))]
    [RequireComponent(typeof(AbilityDuration))]
    public class VampirismAbility : MonoBehaviour
    {
        [SerializeField] private float _damageDeltaTime = 0.25f;
    
        [SerializeField] private Attacker _attacker;
        [SerializeField] private Health _health;
    
        private Cooldown _cooldown;
        private AbilityDuration _abilityDuration;

        private Coroutine _vampirismCoroutine;

        public event Action Stared;
        public event Action Ended;

        protected virtual void Awake()
        {
            _cooldown = GetComponent<Cooldown>();
            _abilityDuration = GetComponent<AbilityDuration>();
        }

        protected void EnableVampirism()
        {
            if (_cooldown.IsExpired())
            {
                _abilityDuration.Begin();
            
                StopVampirismCoroutine();

                _vampirismCoroutine = StartCoroutine(Vampirize());
            
                Stared?.Invoke();
            }
        }

        private void StopVampirismCoroutine()
        {
            if (_vampirismCoroutine != null)
            {
                StopCoroutine(_vampirismCoroutine);
                _vampirismCoroutine = null;
            }
        }

        private IEnumerator Vampirize()
        {
            WaitForSeconds wait = new WaitForSeconds(_damageDeltaTime);

            while (_abilityDuration.IsEnd() == false)
            {
                if (_attacker.CanDealDamage())
                {
                    int dealtDamage = _attacker.DealDamageNearest();
                    _health.HealItself(dealtDamage);
                }
            
                yield return wait;
            }
        
            _cooldown.Reset();
        
            Ended?.Invoke();
        }
    }
}