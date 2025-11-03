using EnemyComponents.StateMachines.States;
using EnemyComponents.StateMachines.Transitions;
using Infrastructure;
using UnityEngine;

namespace EnemyComponents.StateMachines.Factory
{
    public class EnemyStateMachineFactory : MonoBehaviour
    {
        public StateMachine Create
        (
            EnemyPatrol enemyPatrol,
            EnemyMover enemyMover,
            VisibilityZone visibilityZone,
            EnemyAttacker enemyAttacker
        )
        {
            StateMachine stateMachine = new StateMachine();

            PatrolState patrolState = new PatrolState(stateMachine, enemyPatrol);
            AttackState attackState = new AttackState(stateMachine, enemyAttacker);
            ChaseState chaseState = new ChaseState(stateMachine, enemyMover, visibilityZone);

            ToPatrolStateTransition toPatrolStateTransition = new ToPatrolStateTransition(patrolState, visibilityZone);
            ToAttackStateTransition toAttackStateTransition = new ToAttackStateTransition(attackState, enemyAttacker);
            ToChaseStateTransition toChaseStateTransition =
                new ToChaseStateTransition(chaseState, visibilityZone, enemyAttacker);

            patrolState.AddTransition(toChaseStateTransition);
            attackState.AddTransition(toPatrolStateTransition);
            attackState.AddTransition(toChaseStateTransition);
            chaseState.AddTransition(toAttackStateTransition);
            chaseState.AddTransition(toPatrolStateTransition);

            stateMachine.ChangeState(patrolState);

            return stateMachine;
        }
    }
}