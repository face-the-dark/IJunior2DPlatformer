using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Mover : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5.0f;
    [SerializeField] private float _jumpForce = 7.0f;

    [SerializeField] private LayerCheck _groundCheck;

    private Rigidbody2D _rigidbody;

    private Vector2 _direction;
    private bool _isGrounded;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        float xVelocity = _direction.x * _moveSpeed;
        float yVelocity = CalculateYVelocity();

        _rigidbody.velocity = new Vector2(xVelocity, yVelocity);

        UpdateSpriteDirection();
    }

    public void SetDirection(Vector2 direction) => 
        _direction = direction;

    private float CalculateYVelocity()
    {
        float yVelocity = _rigidbody.velocity.y;

        bool isJumpPressing = _direction.y > 0;

        if (_groundCheck.IsTouchingLayer && isJumpPressing) 
            yVelocity = _jumpForce;

        return yVelocity;
    }

    private void UpdateSpriteDirection()
    {
        if (_direction.x > 0)
            transform.localScale = new Vector3(1, 1, 1);
        else if (_direction.x < 0) 
            transform.localScale = new Vector3(-1, 1, 1);
    }
}