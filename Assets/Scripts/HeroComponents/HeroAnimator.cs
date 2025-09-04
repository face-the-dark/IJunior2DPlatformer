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

        protected override void OnEnable()
        {
            base.OnEnable();

            _hero.VerticalVelocityChanged += OnVerticalVelocityChanged;
            _hero.GroundedChanged += OnGroundedChanged;
        }

        protected override void OnDisable()
        {
            base.OnDisable();
            
            _hero.VerticalVelocityChanged -= OnVerticalVelocityChanged;
        }

        private void OnVerticalVelocityChanged(float velocityY) => 
            Animator.SetFloat(VerticalVelocityKey, velocityY);

        private void OnGroundedChanged(bool isGrounded) => 
            Animator.SetBool(IsGroundedKey, isGrounded);
    }
}