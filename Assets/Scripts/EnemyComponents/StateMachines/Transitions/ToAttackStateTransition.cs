using Infrastructure;

namespace EnemyComponents.StateMachines.Transitions
{
    public class ToAttackStateTransition : Transition
    {
        private Attacker _enemyAttacker;
        
        public ToAttackStateTransition(State nextState, Attacker enemyAttacker) : base(nextState) => 
            _enemyAttacker = enemyAttacker;

        protected override bool CanTransit() => 
            _enemyAttacker.CanDealDamage();
    }
}