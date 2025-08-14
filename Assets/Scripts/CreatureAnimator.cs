using UnityEngine;

[RequireComponent(typeof(Movement))]
[RequireComponent(typeof(Health))]
[RequireComponent(typeof(Animator))]
public class CreatureAnimator : MonoBehaviour
{
    private static readonly int IsRunningKey = Animator.StringToHash("IsRunning");
    private static readonly int HitKey = Animator.StringToHash("Hit");

    private Movement _movement;
    private Health _health;

    protected Animator Animator;

    protected virtual void Awake()
    {
        _movement = GetComponent<Movement>();
        _health = GetComponent<Health>();
        Animator = GetComponent<Animator>();
    }

    private void OnEnable() => 
        _health.DamageTaken += PlayHit;

    private void OnDisable() => 
        _health.DamageTaken -= PlayHit;

    protected virtual void FixedUpdate() => 
        Animator.SetBool(IsRunningKey, _movement.DirectionX != 0);

    private void PlayHit() => 
        Animator.SetTrigger(HitKey);
}