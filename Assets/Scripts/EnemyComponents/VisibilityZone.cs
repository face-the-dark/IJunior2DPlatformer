using System;
using HeroComponents;
using UnityEngine;

namespace EnemyComponents
{
    public class VisibilityZone : MonoBehaviour
    {
        public event Action<Hero> HeroEntered;
        public event Action HeroExited;

        public bool IsHeroInZone { get; private set; }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out Hero hero))
            {
                IsHeroInZone = true;
                HeroEntered?.Invoke(hero);
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.TryGetComponent(out Hero hero))
            {
                IsHeroInZone = false;
                HeroExited?.Invoke();
            }
        }
    }
}