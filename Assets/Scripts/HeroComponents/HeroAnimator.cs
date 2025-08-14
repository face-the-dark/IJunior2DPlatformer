using UnityEngine;

namespace HeroComponents
{
    [RequireComponent(typeof(Hero))]
    public class HeroAnimator : CreatureAnimator
    {
        private static readonly int VerticalVelocityKey = Animator.StringToHash("VerticalVelocity");
        private static readonly int IsGroundedKey = Animator.StringToHash("IsGrounded");

        private Hero _hero;
        
        protected override void Awake()
        {
            base.Awake();
            
            _hero = GetComponent<Hero>();
        }

        protected override void FixedUpdate()
        {
            base.FixedUpdate();

            Animator.SetFloat(VerticalVelocityKey, _hero.RigidbodyVelocityY);
            Animator.SetBool(IsGroundedKey, _hero.IsGrounded);
        }
    }
}