using System.Collections;
using HeroComponents;
using UnityEngine;

namespace Enemy
{
    public class EnemyAttacker : Attacker
    {
        [SerializeField] protected float _attackCooldown = 1f;

        protected override void DealDamage()
        {
            Collider2D[] targets = GetTargets();

            foreach (Collider2D target in targets)
                if (target.TryGetComponent(out HeroHealth heroHealth))
                    heroHealth.TakeDamage(Damage);
        }

        public IEnumerator AttackHero()
        {
            WaitForSeconds attackCooldownSeconds = new WaitForSeconds(_attackCooldown);
            
            while (enabled && CanAttack())
            {
                DealDamage();
                
                yield return attackCooldownSeconds;
            }
        }

        private bool CanAttack()
        {
            Collider2D[] targets = GetTargets();

            foreach (Collider2D target in targets)
                if (target.TryGetComponent(out HeroHealth heroHealth))
                    return true;

            return false;
        }
    }
}