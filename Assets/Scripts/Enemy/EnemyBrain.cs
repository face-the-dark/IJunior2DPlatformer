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

        private Patrol _patrol;
        private EnemyAttacker _attacker;
        private EnemyMover _mover;

        private State _currentState;
        private Coroutine _currentCoroutine;
        private Hero _hero;

        private void Awake()
        {
            _patrol = GetComponent<Patrol>();
            _attacker = GetComponent<EnemyAttacker>();
            _mover = GetComponent<EnemyMover>();
        }

        private void Start() => 
            SwitchState(State.Patrol);

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

            SwitchState(State.Chase);
        }

        private void OnHeroExited()
        {
            _hero = null;
            
            SwitchState(State.Patrol);
        }

        private void SwitchState(State newState)
        {
            if (_currentState == newState)
                return;
            
            StopCurrentCoroutine();

            _currentState = newState;

            switch (_currentState)
            {
                case State.Patrol:
                    _currentCoroutine = StartCoroutine(DoPatrol());
                    break;

                case State.Chase:
                    _currentCoroutine = StartCoroutine(GoToHero());
                    break;

                case State.Attack:
                    _currentCoroutine = StartCoroutine(AttackHero());
                    break;
            }
        }

        private void StopCurrentCoroutine()
        {
            if (_currentCoroutine != null)
            {
                StopCoroutine(_currentCoroutine);
                _currentCoroutine = null;
            }
        }

        private IEnumerator DoPatrol()
        {
            yield return _patrol.DoPatrol();
            
            SwitchState(State.Patrol);
        }

        private IEnumerator GoToHero()
        {
            yield return _mover.GoToHero(_hero);
            
            SwitchState(State.Attack);
        }

        private IEnumerator AttackHero()
        {
            yield return _attacker.AttackHero();

            SwitchState(State.Chase);
        }
    }
}