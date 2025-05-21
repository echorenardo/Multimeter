using System;
using StateMachine;
using Initializing;
using InputControlling;
using MeasuringTarget;

namespace Multimeter
{
    public class MultimeterModel : IInitializable, IDisposable
    {
        public event Action StateChanged;

        private IInputController _inputController;
        private StateMachine<MultimeterModel, MultimeterState> _stateMachine;

        public MultimeterState CurrentState => _stateMachine.CurrentState;
        public IMeasurementTarget MeasurementTarget { get; private set; }
        public float CurrentMeasuredValue {  get; private set; }

        public MultimeterModel(IInputController inputController, IMeasurementTarget measurementTarget = null)
        {
            _stateMachine = new(this);

            _inputController = inputController;
            MeasurementTarget = measurementTarget;
        }

        public void Initialize()
        {
            FillStates();

            _inputController.MultimeterSwitcherScrolled += OnMultimeterSwitcherScrolled;

            SwitchState<OffMultimeterState>();
        }

        public void Dispose()
        {
            _inputController.MultimeterSwitcherScrolled -= OnMultimeterSwitcherScrolled;
        }

        public void SwitchState<TState>() where TState : MultimeterState
        {
            _stateMachine.SwitchState<TState>();

            StateChanged?.Invoke();
        }

        public void SetMeasuredValue(float measuredValue)
        {
            CurrentMeasuredValue = measuredValue;
        }

        private void FillStates()
        {
            _stateMachine.AddState(new OffMultimeterState(this));
            _stateMachine.AddState(new AmpereMultimeterState(this));
            _stateMachine.AddState(new ResistanceMultimeterState(this));
            _stateMachine.AddState(new ACVoltageMultimeterState(this));
            _stateMachine.AddState(new DCVoltageMultimeterState(this));
        }

        #region Event Handler
        private void OnMultimeterSwitcherScrolled(bool isForward)
        {
            _stateMachine.CurrentState.OnSwitcherScrolled(isForward);
        }

        #endregion
    }
}