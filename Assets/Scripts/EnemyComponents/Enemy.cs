using EnemyComponents.StateMachines.Factory;
using Infrastructure;
using UnityEngine;

namespace EnemyComponents
{
    [RequireComponent(typeof(EnemyPatrol))]
    [RequireComponent(typeof(EnemyMover))]
    [RequireComponent(typeof(EnemyAttacker))]
    [RequireComponent(typeof(Health))]
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(EnemyStateMachineFactory))]
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private VisibilityZone _visibilityZone;
        [SerializeField] private float _damageForce = 10.0f;

        private EnemyPatrol _enemyPatrol;
        private EnemyMover _mover;
        private EnemyAttacker _enemyAttacker;
        private Health _health;
        
        private Rigidbody2D _rigidbody;

        private StateMachine _stateMachine;

        private void Awake()
        {
            _mover = GetComponent<EnemyMover>();
            _health = GetComponent<Health>();
            _rigidbody = GetComponent<Rigidbody2D>();

            _enemyPatrol = GetComponent<EnemyPatrol>();
            _enemyAttacker = GetComponent<EnemyAttacker>();
            
            _stateMachine = GetComponent<EnemyStateMachineFactory>().Create
            (
                _enemyPatrol,
                _mover,
                _visibilityZone,
                _enemyAttacker
            );
        }

        private void OnEnable() =>
            _health.DamageTaken += OnDamageTaken;

        private void OnDisable() =>
            _health.DamageTaken -= OnDamageTaken;

        private void Update() =>
            _stateMachine?.Update();

        private void FixedUpdate()
        {
            float xVelocity = _mover.CalculateXVelocity(_rigidbody.velocity.x);

            _rigidbody.velocity = new Vector2(xVelocity, _rigidbody.velocity.y);
        }

        private void OnDamageTaken() =>
            _rigidbody.AddForce(Vector2.up * _damageForce, ForceMode2D.Impulse);
    }
}