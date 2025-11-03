using Infrastructure;

namespace EnemyComponents.StateMachines.Transitions
{
    public class ToChaseStateTransition : Transition
    {
        private VisibilityZone _visibilityZone;
        private EnemyAttacker _enemyAttacker;

        public ToChaseStateTransition
        (
            State nextState,
            VisibilityZone visibilityZone,
            EnemyAttacker enemyAttacker
        ) : base(nextState)
        {
            _visibilityZone = visibilityZone;
            _enemyAttacker = enemyAttacker;
        }

        protected override bool CanTransit() =>
            _visibilityZone.IsHeroInZone && _enemyAttacker.CanAttack() == false;
    }
}