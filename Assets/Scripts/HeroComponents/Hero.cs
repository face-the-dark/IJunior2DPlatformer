using UnityEngine;

namespace HeroComponents
{
    [RequireComponent(typeof(HeroMover))]
    [RequireComponent(typeof(Jumper))]
    [RequireComponent(typeof(Rigidbody2D))]
    public class Hero : MonoBehaviour
    {
        private HeroMover _mover;
        private Jumper _jumper;
        
        private Rigidbody2D _rigidbody;

        public bool IsGrounded => _jumper.IsGrounded;
        public float RigidbodyVelocityY => _rigidbody.velocity.y;
        
        private void Awake()
        {
            _mover =  GetComponent<HeroMover>();
            _jumper = GetComponent<Jumper>();
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            float xVelocity = _mover.CalculateXVelocity(_rigidbody.velocity.x);
            float yVelocity = _jumper.CalculateYVelocity(_rigidbody.velocity.y);

            _rigidbody.velocity = new Vector2(xVelocity, yVelocity);
        }
    }
}