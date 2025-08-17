using Enemy;
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

        protected override void DealDamage()
        {
            Collider2D[] targets = GetTargets();

            foreach (Collider2D target in targets)
                if (target.TryGetComponent(out EnemyHealth enemyHealth))
                    enemyHealth.TakeDamage(Damage);
        }
    }
}