using Infrastructure;

namespace EnemyComponents.StateMachines.States
{
    public class PatrolState : State
    {
        private EnemyPatrol _enemyPatrol;
        
        public PatrolState(IStateChanger stateChanger, EnemyPatrol enemyPatrol) : base(stateChanger) => 
            _enemyPatrol = enemyPatrol;

        protected override void OnUpdate() => 
            _enemyPatrol.DoPatrol();
    }
}