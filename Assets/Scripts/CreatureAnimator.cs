using UnityEngine;

[RequireComponent(typeof(Animator))]
public class CreatureAnimator : MonoBehaviour
{
    private static readonly int IsRunningKey = Animator.StringToHash("IsRunning");

    private Movement _movement;
    
    protected Animator Animator;

    protected virtual void Awake()
    {
        _movement = GetComponent<Movement>();
        Animator = GetComponent<Animator>();
    }

    protected virtual void FixedUpdate() => 
        Animator.SetBool(IsRunningKey, _movement.DirectionX != 0);
}