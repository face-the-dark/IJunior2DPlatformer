using UnityEngine;

namespace HeroComponents
{
    [RequireComponent(typeof(HeroMover))]
    [RequireComponent(typeof(Jumper))]
    [RequireComponent(typeof(Health))]
    [RequireComponent(typeof(Rigidbody2D))]
    public class Hero : MonoBehaviour
    {
        [SerializeField] private float _damageForce = 10.0f;
        
        private HeroMover _mover;
        private Jumper _jumper;
        private Health _health;
        private Rigidbody2D _rigidbody;

        public bool IsGrounded => _jumper.IsGrounded;
        public float RigidbodyVelocityY => _rigidbody.velocity.y;
        
        private void Awake()
        {
            _mover =  GetComponent<HeroMover>();
            _jumper = GetComponent<Jumper>();
            _health = GetComponent<Health>();
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void OnEnable() => 
            _health.DamageTaken += OnDamageTaken;

        private void OnDisable() => 
            _health.DamageTaken -= OnDamageTaken;

        private void OnDamageTaken() => 
            _rigidbody.AddForce(Vector2.up * _damageForce, ForceMode2D.Impulse);

        private void FixedUpdate()
        {
            float xVelocity = _mover.CalculateXVelocity(_rigidbody.velocity.x);
            float yVelocity = _jumper.CalculateYVelocity(_rigidbody.velocity.y);

            _rigidbody.velocity = new Vector2(xVelocity, yVelocity);
        }
    }
}