using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class HeroMovement : MonoBehaviour
{
    private const float One = 1;

    [SerializeField] private float _moveSpeed = 5.0f;
    [SerializeField] private float _jumpForce = 10.0f;
    
    [SerializeField] private float _coyoteTime = 0.2f;
    [SerializeField] private float _jumpBufferTime = 0.2f;

    [SerializeField] private LayerCheck _groundCheck;

    private Rigidbody2D _rigidbody;

    private Vector2 _direction;
    
    private bool _isGrounded;
    private bool _isJumpPressing;
    
    private float _coyoteTimeCounter;
    private float _jumpBufferCounter;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _isGrounded = _groundCheck.IsTouchingLayer;
        _isJumpPressing = _direction.y > 0;

        UpdateCoyoteCounter();
        UpdateJumpBufferCounter();
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

    private void UpdateCoyoteCounter()
    {
        if (_isGrounded)
            _coyoteTimeCounter = _coyoteTime;
        else
            _coyoteTimeCounter -= Time.deltaTime;
    }

    private void UpdateJumpBufferCounter()
    {
        if (_isJumpPressing)
            _jumpBufferCounter = _jumpBufferTime;
        else
            _jumpBufferCounter -= Time.deltaTime;
    }

    private float CalculateYVelocity()
    {
        float yVelocity = _rigidbody.velocity.y;
        
        if (_coyoteTimeCounter > 0 && _jumpBufferCounter > 0)
        {
            yVelocity = _jumpForce;
            _jumpBufferCounter = 0;
        }

        if (_isJumpPressing == false && _rigidbody.velocity.y > 0)
        {
            yVelocity *= 0.5f;
            _coyoteTimeCounter = 0;
        }

        return yVelocity;
    }

    private void UpdateSpriteDirection()
    {
        if (_direction.x > 0)
            transform.localScale = new Vector3(One, One, One);
        else if (_direction.x < 0)
            transform.localScale = new Vector3(-One, One, One);
    }
}