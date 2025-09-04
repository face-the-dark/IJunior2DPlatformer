using System;
using HeroComponents;
using Infrastructure;

namespace EnemyComponents.StateMachines.States
{
    public class ChaseState : State, IDisposable
    {
        private EnemyMover _enemyMover;
        private VisibilityZone _visibilityZone;

        private Hero _hero;

        public ChaseState
        (
            IStateChanger stateChanger,
            EnemyMover enemyMover,
            VisibilityZone visibilityZone
        ) : base(stateChanger)
        {
            _enemyMover = enemyMover;
            _visibilityZone = visibilityZone;

            _visibilityZone.HeroEntered += OnHeroEntered;
            _visibilityZone.HeroExited += OnHeroExited;
        }

        public void Dispose()
        {
            _visibilityZone.HeroEntered -= OnHeroEntered;
            _visibilityZone.HeroExited -= OnHeroExited;
        }

        protected override void OnUpdate()
        {
            if (_hero != null)
                _enemyMover.GoToHero(_hero);
        }

        private void OnHeroEntered(Hero hero) =>
            _hero = hero;

        private void OnHeroExited() =>
            _hero = null;
    }
}