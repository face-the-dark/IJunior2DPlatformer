using UnityEngine;

namespace Enemy
{
    [RequireComponent(typeof(EnemyMovement))]
    [RequireComponent(typeof(Health))]
    [RequireComponent(typeof(Rigidbody2D))]
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private float _damageForce = 10.0f;
        
        private EnemyMovement _movement;
        private Health _health;
        private Rigidbody2D _rigidbody;

        private void Awake()
        {
            _movement = GetComponent<EnemyMovement>();
            _rigidbody = GetComponent<Rigidbody2D>();
            _health = GetComponent<Health>();
        }
        
        private void OnEnable() => 
            _health.DamageTaken += OnDamageTaken;

        private void OnDisable() => 
            _health.DamageTaken -= OnDamageTaken;

        private void OnDamageTaken() => 
            _rigidbody.AddForce(Vector2.up * _damageForce, ForceMode2D.Impulse);

        private void FixedUpdate()
        {
            float xVelocity = _movement.CalculateXVelocity(_rigidbody.velocity.x);

            _rigidbody.velocity = new Vector2(xVelocity, _rigidbody.velocity.y);
        }
    }
}