using UnityEngine;

namespace Hero
{
    [RequireComponent(typeof(HeroMovement))]
    [RequireComponent(typeof(Jumper))]
    [RequireComponent(typeof(Rigidbody2D))]
    public class Hero : MonoBehaviour
    {
        private HeroMovement _movement;
        private Jumper _jumper;
        private Rigidbody2D _rigidbody;

        public bool IsGrounded => _jumper.IsGrounded;
        public float RigidbodyVelocityY => _rigidbody.velocity.y;
        
        private void Awake()
        {
            _movement =  GetComponent<HeroMovement>();
            _jumper = GetComponent<Jumper>();
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            float xVelocity = _movement.CalculateXVelocity(_rigidbody.velocity.x);
            float yVelocity = _jumper.CalculateYVelocity(_rigidbody.velocity.y);

            _rigidbody.velocity = new Vector2(xVelocity, yVelocity);
        }
    }
}