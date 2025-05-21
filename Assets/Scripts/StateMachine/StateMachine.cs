using System;
using System.Collections.Generic;

namespace StateMachine
{
    public class StateMachine<T, S> where S : State<T>
    {
        private readonly T _owner;
        private readonly Dictionary<Type, S> _states;

        private S _currentState;

        public S CurrentState => _currentState;

        public StateMachine(T owner)
        {
            _owner = owner;

            _states = new();
        }

        public void AddState(S state)
        {
            _states[state.GetType()] = state;
        }

        public void SwitchState<TState>() where TState : S
        {
            Type type = typeof(TState);

            if (!_states.ContainsKey(type))
                throw new Exception("This state does not exist");

            S newState = _states[type];

            if (newState == _currentState)
                return;

            _currentState = newState;
            _currentState.OnEnter();
        }
    }
}