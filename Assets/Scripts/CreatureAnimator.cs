using UnityEngine;

[RequireComponent(typeof(Animator))]
public class CreatureAnimator : MonoBehaviour
{
    private static readonly int IsRunningKey = Animator.StringToHash("IsRunning");

    protected Animator Animator;
    protected Movement Movement;

    private void Awake()
    {
        Animator = GetComponent<Animator>();
        Movement = GetComponent<Movement>();
    }

    protected virtual void FixedUpdate()
    {
        Animator.SetBool(IsRunningKey, Movement.DirectionX != 0);
    }

}