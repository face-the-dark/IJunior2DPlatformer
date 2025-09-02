using HeroComponents;
using UnityEngine;

namespace EnemyComponents
{
    [RequireComponent(typeof(EnemyPatrol))]
    public class EnemyMover : Mover
    {
        [SerializeField] private float _treshold = 2f;
        
        private EnemyPatrol _enemyPatrol;
        
        protected void Awake() => 
            _enemyPatrol = GetComponent<EnemyPatrol>();

        private void OnEnable() => 
            _enemyPatrol.DirectionChanged += SetDirection;

        private void OnDisable() => 
            _enemyPatrol.DirectionChanged -= SetDirection;

        public void GoToHero(Hero hero)
        {
            if (IsNearHero(hero) == false)
            {
                Vector2 directionToHero = (hero.transform.position - transform.position).normalized;
                directionToHero.y = 0;
            
                SetDirection(directionToHero);
            }
        }

        private bool IsNearHero(Hero hero) => 
            (hero.transform.position - transform.position).sqrMagnitude < _treshold;
    }
}