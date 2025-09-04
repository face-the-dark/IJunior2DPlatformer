using System;
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
        
        private bool _isLastGrounded;
        private float _lastRigidbodyVelocityY;
        
        public event Action<bool> GroundedChanged;
        public event Action<float> VerticalVelocityChanged;
        
        private void Awake()
        {
            _mover =  GetComponent<HeroMover>();
            _jumper = GetComponent<Jumper>();
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            CacheLastVariables();

            float xVelocity = _mover.CalculateXVelocity(_rigidbody.velocity.x);
            float yVelocity = _jumper.CalculateYVelocity(_rigidbody.velocity.y);

            _rigidbody.velocity = new Vector2(xVelocity, yVelocity);
        }

        private void CacheLastVariables()
        {
            bool isGrounded = _jumper.IsGrounded;
            float velocityY = _rigidbody.velocity.y;
            
            if (isGrounded != _isLastGrounded)
            {
                GroundedChanged?.Invoke(isGrounded);
                _isLastGrounded = isGrounded;
            }

            if (Mathf.Approximately(_lastRigidbodyVelocityY, velocityY) == false)
            {
                VerticalVelocityChanged?.Invoke(velocityY);
                _lastRigidbodyVelocityY = velocityY;
            }
        }
    }
}