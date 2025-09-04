using Infrastructure;

namespace EnemyComponents.StateMachines.Transitions
{
    public class ToPatrolStateTransition : Transition
    {
        private VisibilityZone _visibilityZone;

        public ToPatrolStateTransition(State nextState, VisibilityZone visibilityZone) : base(nextState) =>
            _visibilityZone = visibilityZone;

        protected override bool CanTransit() =>
            _visibilityZone.IsHeroInZone == false;
    }
}