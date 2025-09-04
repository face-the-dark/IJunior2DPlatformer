using UnityEngine;

[RequireComponent(typeof(Mover))]
[RequireComponent(typeof(Health))]
[RequireComponent(typeof(Animator))]
public class CreatureAnimator : MonoBehaviour
{
    private static readonly int IsRunningKey = Animator.StringToHash("IsRunning");
    private static readonly int HitKey = Animator.StringToHash("Hit");

    private Mover _mover;
    private Health _health;

    protected Animator Animator;

    protected virtual void Awake()
    {
        _mover = GetComponent<Mover>();
        _health = GetComponent<Health>();
        Animator = GetComponent<Animator>();
    }

    protected virtual void OnEnable()
    {
        _mover.DirectionChanged += OnDirectionChanged;
        _health.DamageTaken += PlayHit;
    }

    protected virtual void OnDisable()
    {
        _mover.DirectionChanged -= OnDirectionChanged;
        _health.DamageTaken -= PlayHit;
    }

    private void OnDirectionChanged(Vector2 direction) => 
        Animator.SetBool(IsRunningKey, direction.x != 0);

    private void PlayHit() => 
        Animator.SetTrigger(HitKey);
}