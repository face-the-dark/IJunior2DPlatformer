using UnityEngine;

namespace Hero
{
    [RequireComponent(typeof(HeroMovement))]
    public class HeroAnimator : CreatureAnimator
    {
        private static readonly int VerticalVelocityKey = Animator.StringToHash("VerticalVelocity");
        private static readonly int IsGroundedKey = Animator.StringToHash("IsGrounded");

        protected override void FixedUpdate()
        {
            base.FixedUpdate();

            Animator.SetFloat(VerticalVelocityKey, Movement.RigidbodyVelocityY);
            Animator.SetBool(IsGroundedKey, Movement.IsGrounded);
        }
    }
}