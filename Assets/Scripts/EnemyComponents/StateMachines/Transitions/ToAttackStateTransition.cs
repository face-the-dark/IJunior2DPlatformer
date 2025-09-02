using Infrastructure;

namespace EnemyComponents.StateMachines.Transitions
{
    public class ToAttackStateTransition : Transition
    {
        private EnemyAttacker _enemyAttacker;
        
        public ToAttackStateTransition(State nextState, EnemyAttacker enemyAttacker) : base(nextState) => 
            _enemyAttacker = enemyAttacker;

        protected override bool CanTransit() => 
            _enemyAttacker.CanAttack();
    }
}