using Infrastructure;

namespace EnemyComponents.StateMachines.Transitions
{
    public class ToChaseStateTransition : Transition
    {
        private VisibilityZone _visibilityZone;
        private Attacker _enemyAttacker;

        public ToChaseStateTransition
        (
            State nextState,
            VisibilityZone visibilityZone,
            Attacker enemyAttacker
        ) : base(nextState)
        {
            _visibilityZone = visibilityZone;
            _enemyAttacker = enemyAttacker;
        }

        protected override bool CanTransit() =>
            _visibilityZone.IsHeroInZone && _enemyAttacker.CanDealDamage() == false;
    }
}