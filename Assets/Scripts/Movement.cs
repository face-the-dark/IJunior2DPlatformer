using UnityEngine;
using Utils;

[RequireComponent(typeof(Rigidbody2D))]
public class Movement : MonoBehaviour
{
    private static readonly Quaternion SpriteDirectionRightRotation = Quaternion.Euler(0f, 0f, 0f);
    private static readonly Quaternion SpriteDirectionLeftRotation = Quaternion.Euler(0f, 180f, 0f);

    [Header("Base Movement Parameters")] [Space]
    [SerializeField] private float _moveSpeed = 5.0f;
    [SerializeField] private float _jumpForce = 10.0f;

    [Header("Advanced Jump Parameters")] [Space]
    [SerializeField] private bool _isMoreJumpControl = false;
    [Range(0.5f, 1.0f)] [SerializeField] private float _jumpControlModifier = 0.5f;
    
    [SerializeField] private float _coyoteTime = 0.2f;
    [SerializeField] private float _jumpBufferTime = 0.1f;

    [Header("Soft Movement Parameters")] [Space]
    [SerializeField] private bool _isSoftMovement = true;
    [SerializeField] private float _softMovementAcceleration = 20.0f;

    [Header("Ground Check Parameters")] [Space]
    [SerializeField] private GroundCheck _groundCheck;

    private Rigidbody2D _rigidbody;

    private Vector2 _direction;
    
    private bool _isGrounded;
    private bool _isJumpPressing;
    
    private float _coyoteTimeCounter;
    private float _jumpBufferCounter;
    
    public float DirectionX => _direction.x;
    public float RigidbodyVelocityY => _rigidbody.velocity.y;
    public bool IsGrounded => _isGrounded;

    protected virtual void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _isGrounded = _groundCheck.IsGrounded;
        _isJumpPressing = _direction.y > 0;

        UpdateCoyoteCounter();
        UpdateJumpBufferCounter();
    }

    private void FixedUpdate()
    {
        float xVelocity = CalculateXVelocity();
        float yVelocity = CalculateYVelocity();

        _rigidbody.velocity = new Vector2(xVelocity, yVelocity);

        UpdateSpriteDirection();
    }

    protected void SetDirection(Vector2 direction) =>
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

    private float CalculateXVelocity()
    {
        float xVelocity = _direction.x * _moveSpeed;
        
        if (_isSoftMovement) 
            xVelocity = Mathf.Lerp(_rigidbody.velocity.x, xVelocity, Time.deltaTime * _softMovementAcceleration);

        return xVelocity;
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
            if (_isMoreJumpControl)
                yVelocity *= _jumpControlModifier;
            
            _coyoteTimeCounter = 0;
        }

        return yVelocity;
    }

    private void UpdateSpriteDirection()
    {
        if (_direction.x > 0)
            transform.rotation = SpriteDirectionRightRotation;
        else if (_direction.x < 0)
            transform.rotation = SpriteDirectionLeftRotation;
    }
}