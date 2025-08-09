using UnityEngine;

namespace Enemy
{
    [RequireComponent(typeof(EnemyMovement))]
    [RequireComponent(typeof(Rigidbody2D))]
    public class Enemy : MonoBehaviour
    {
        private EnemyMovement _movement;
        private Rigidbody2D _rigidbody;

        private void Awake()
        {
            _movement = GetComponent<EnemyMovement>();
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            float xVelocity = _movement.CalculateXVelocity(_rigidbody.velocity.x);

            _rigidbody.velocity = new Vector2(xVelocity, _rigidbody.velocity.y);
        }
    }
}