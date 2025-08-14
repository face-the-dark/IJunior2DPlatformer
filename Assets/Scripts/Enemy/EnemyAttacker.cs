using HeroComponents;
using UnityEngine;

namespace Enemy
{
    public class EnemyAttacker : Attacker
    {
        public void Attack() => 
            DealDamage();

        public bool CanAttack()
        {
            Collider2D[] targets = GetTargets();

            foreach (Collider2D target in targets)
                if (target.TryGetComponent(out Hero hero))
                    return true;
            
            return false;
        }
    }
}