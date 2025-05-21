using System;

namespace Multimeter
{
    public class DCVoltageMultimeterState : MultimeterState
    {
        private readonly float _defaultValue = 0.01f;

        public DCVoltageMultimeterState(MultimeterModel multimeter) : base(multimeter, PhysicalQuantityType.DCVoltage) { }

        public override void OnSwitcherScrolled(bool isForward)
        {
            if (isForward == false)
                _multimeter.SwitchState<ACVoltageMultimeterState>();
        }

        protected override void Calculate()
        {
            float measuredValue = _multimeter.MeasurementTarget == null
                ? EmptyMeasuringTargetValue
                : _defaultValue;

            _multimeter.SetMeasuredValue(measuredValue);
        }
    }
}