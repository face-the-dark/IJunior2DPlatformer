using System;
using HeroComponents;
using UnityEngine;

namespace Enemy
{
    public class AttackZone : MonoBehaviour
    {
        public event Action<Hero> HeroEntered;
        public event Action HeroExited;
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out Hero hero)) 
                HeroEntered?.Invoke(hero);
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.TryGetComponent(out Hero hero)) 
                HeroExited?.Invoke();
        }
    }
}