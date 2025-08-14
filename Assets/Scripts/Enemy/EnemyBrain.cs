using System;
using System.Collections;
using HeroComponents;
using UnityEngine;

namespace Enemy
{
    [RequireComponent(typeof(Patrol))]
    [RequireComponent(typeof(EnemyAttacker))]
    public class EnemyBrain : MonoBehaviour
    {
        [SerializeField] private AttackZone _attackZone;
        [SerializeField] protected float _attackCooldown = 1f;

        private Patrol _patrol;
        private EnemyAttacker _enemyAttacker;
        
        private Coroutine _currentCoroutine;
        private Hero _hero;
        
        public event Action<Vector2> DirectionChangedToHero;

        private void Awake()
        {
            _patrol = GetComponent<Patrol>();
            _enemyAttacker = GetComponent<EnemyAttacker>();
        }

        private void Start() => 
            _currentCoroutine = StartCoroutine(_patrol.DoPatrol());

        private void OnEnable()
        {
            _attackZone.HeroEntered += OnHeroEntered;
            _attackZone.HeroExited += OnHeroExited;
        }

        private void OnDisable()
        {
            _attackZone.HeroEntered -= OnHeroEntered;
            _attackZone.HeroExited -= OnHeroExited;
        }

        private void OnHeroEntered(Hero hero)
        {
            _hero = hero;
            
            StopCurrentCoroutine();

            _currentCoroutine = StartCoroutine(GoToHero());
        }

        private void OnHeroExited()
        {
            _hero = null;
            
            StopCurrentCoroutine();

            _currentCoroutine = StartCoroutine(_patrol.DoPatrol());
        }

        private IEnumerator GoToHero()
        {
            while (enabled && _enemyAttacker.CanAttack() == false)
            {
                Vector2 directionToHero = _hero.transform.position - transform.position;
            
                directionToHero.y = 0;
                directionToHero.Normalize();
            
                DirectionChangedToHero?.Invoke(directionToHero);
                
                yield return null;
            }
            
            StopCurrentCoroutine();
            
            _currentCoroutine = StartCoroutine(AttackHero());
        }

        private IEnumerator AttackHero()
        {
            while (enabled && _enemyAttacker.CanAttack())
            {
                _enemyAttacker.Attack();
                
                yield return new WaitForSeconds(_attackCooldown);
            }
            
            StopCurrentCoroutine();
            
            _currentCoroutine = StartCoroutine(GoToHero());
        }

        private void StopCurrentCoroutine()
        {
            if (_currentCoroutine != null)
            {
                StopCoroutine(_currentCoroutine);
                _currentCoroutine = null;
            }
        }
    }
}
