using System.Collections;
using HeroComponents;
using UnityEngine;

namespace Enemy
{
    [RequireComponent(typeof(Patrol))]
    public class EnemyMover : Mover
    {
        [SerializeField] private float _treshold = 2f;
        
        private Patrol _patrol;
        
        protected void Awake() => 
            _patrol = GetComponent<Patrol>();

        private void OnEnable() => 
            _patrol.DirectionChanged += SetDirection;

        private void OnDisable() => 
            _patrol.DirectionChanged -= SetDirection;

        public IEnumerator GoToHero(Hero hero)
        {
            while (enabled && IsNearHero(hero) == false)
            {
                Vector2 directionToHero = (hero.transform.position - transform.position).normalized;
                directionToHero.y = 0;
            
                SetDirection(directionToHero);
                
                yield return null;
            }
        }

        private bool IsNearHero(Hero hero) => 
            (hero.transform.position - transform.position).sqrMagnitude < _treshold;
    }
}