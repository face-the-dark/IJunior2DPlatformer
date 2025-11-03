using Infrastructure;

namespace EnemyComponents.StateMachines.States
{
    public class AttackState : State
    {
        private Attacker _enemyAttacker;

        public AttackState(IStateChanger stateChanger, Attacker enemyAttacker) : base(stateChanger) =>
            _enemyAttacker = enemyAttacker;

        protected override void OnUpdate() =>
            _enemyAttacker.Attack();
    }
}