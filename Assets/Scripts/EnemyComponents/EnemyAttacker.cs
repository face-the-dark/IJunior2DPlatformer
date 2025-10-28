using HeroComponents;
using UnityEngine;

namespace EnemyComponents
{
    [RequireComponent(typeof(Cooldown))]
    public class EnemyAttacker : Attacker
    {
        private Cooldown _cooldown;

        private void Awake() => 
            _cooldown = GetComponent<Cooldown>();

        public void AttackHero()
        {
            if (CanAttack())
            {
                DealDamage();
                _cooldown.Reset();
            }
        }

        public bool CanAttack()
        {
            Collider2D[] targets = GetTargets();

            foreach (Collider2D target in targets)
                if (target.TryGetComponent(out HeroHealth heroHealth) && _cooldown.IsExpired())
                    return true;

            return false;
        }

        public override bool CanDealDamage()
        {
            Collider2D[] targets = GetTargets();

            foreach (Collider2D target in targets)
                if (target.TryGetComponent(out HeroHealth heroHealth))
                    return true;

            return false;
        }

        protected override void DealDamage()
        {
            Collider2D[] targets = GetTargets();

            foreach (Collider2D target in targets)
                if (target.TryGetComponent(out HeroHealth heroHealth))
                    heroHealth.TakeDamage(Damage);
        }

        public override int DealDamageNearest() => 0;
    }
}