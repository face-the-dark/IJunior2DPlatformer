using HeroComponents;
using UnityEngine;
using Utils;

[RequireComponent(typeof(HeroInputReader))]
public class Jumper : MonoBehaviour
{
    [SerializeField] private float _jumpForce = 10.0f;
    [SerializeField] private bool _isMoreJumpControl = false;
    [Range(0.5f, 1.0f)] [SerializeField] private float _jumpControlModifier = 0.5f;
    
    [SerializeField] private float _coyoteTime = 0.2f;
    [SerializeField] private float _jumpBufferTime = 0.1f;
    
    [Header("Ground Check Parameters")] [Space]
    [SerializeField] private GroundCheck _groundCheck;
    
    private HeroInputReader _inputReader;
    
    private bool _isGrounded;
    private bool _isJumpPressing;
    
    private float _coyoteTimeCounter;
    private float _jumpBufferCounter;
    
    private Vector2 _direction;
    
    public bool IsGrounded => _isGrounded;

    private void Awake() => 
        _inputReader = GetComponent<HeroInputReader>();

    private void OnEnable() => 
        _inputReader.DirectionChanged += SetDirection;

    private void OnDisable() => 
        _inputReader.DirectionChanged -= SetDirection;

    private void Update()
    {
        _isGrounded = _groundCheck.IsGrounded;
        _isJumpPressing = _direction.y > 0;

        UpdateCoyoteCounter();
        UpdateJumpBufferCounter();
    }

    public float CalculateYVelocity(float rigidbodyVelocityY)
    {
        float yVelocity = rigidbodyVelocityY;
        
        if (_coyoteTimeCounter > 0 && _jumpBufferCounter > 0)
        {
            yVelocity = _jumpForce;
            _jumpBufferCounter = 0;
        }

        if (_isJumpPressing == false && rigidbodyVelocityY > 0)
        {
            if (_isMoreJumpControl)
                yVelocity *= _jumpControlModifier;
            
            _coyoteTimeCounter = 0;
        }

        return yVelocity;
    }

    private void SetDirection(Vector2 direction) => 
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
}