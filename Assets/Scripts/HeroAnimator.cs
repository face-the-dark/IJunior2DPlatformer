using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
public class HeroAnimator : MonoBehaviour
{
    private static readonly int IsRunningKey = Animator.StringToHash("IsRunning");
    private static readonly int VerticalVelocityKey = Animator.StringToHash("VerticalVelocity");
    private static readonly int IsGroundedKey = Animator.StringToHash("IsGrounded");

    [SerializeField] private LayerCheck _groundCheck;
    
    private Animator _animator;
    private Rigidbody2D _rigidbody;

    private Vector2 _direction;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        _animator.SetBool(IsRunningKey, _direction.x != 0);
        _animator.SetFloat(VerticalVelocityKey, _rigidbody.velocity.y);
        _animator.SetBool(IsGroundedKey, _groundCheck.IsTouchingLayer);
    }

    public void SetDirection(Vector2 direction) => 
        _direction = direction;
}