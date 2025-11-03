using Infrastructure;

namespace EnemyComponents.StateMachines.States
{
    public class AttackState : State
    {
        private EnemyAttacker _enemyAttacker;

        public AttackState(IStateChanger stateChanger, EnemyAttacker enemyAttacker) : base(stateChanger) =>
            _enemyAttacker = enemyAttacker;

        protected override void OnUpdate() =>
            _enemyAttacker.AttackHero();
    }
}