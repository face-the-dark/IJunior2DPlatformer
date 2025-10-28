using EnemyComponents;
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
        
        public override bool CanDealDamage()
        {
            Collider2D[] targets = GetTargets();

            foreach (Collider2D target in targets)
                if (target.TryGetComponent(out EnemyHealth enemyHealth))
                    return true;

            return false;
        }

        public override int DealDamageNearest()
        {
            EnemyHealth enemyHealth = DefineNearestEnemy(GetTargets());

            if (enemyHealth is not null)
            {
                enemyHealth.TakeDamage(Damage);
                
                return Damage;
            }

            return 0;
        }

        protected override void DealDamage()
        {
            Collider2D[] targets = GetTargets();

            foreach (Collider2D target in targets)
                if (target.TryGetComponent(out EnemyHealth enemyHealth))
                    enemyHealth.TakeDamage(Damage);
        }

        private EnemyHealth DefineNearestEnemy(Collider2D[] targets)
        {
            targets[0].TryGetComponent(out EnemyHealth nearestEnemyHealth);

            foreach (Collider2D target in targets)
            {
                if (target.TryGetComponent(out EnemyHealth enemyHealth))
                {
                    Transform targetPosition = enemyHealth.transform;

                    if (nearestEnemyHealth is null)
                    {
                        nearestEnemyHealth = enemyHealth;
                    }
                    else
                    {
                        if (targetPosition.position.magnitude < nearestEnemyHealth.transform.position.magnitude)
                        {
                            nearestEnemyHealth = enemyHealth;
                        }
                    }
                }
            }
            
            return nearestEnemyHealth;
        }
    }
}