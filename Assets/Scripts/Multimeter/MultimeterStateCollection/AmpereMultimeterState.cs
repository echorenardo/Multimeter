using System;

namespace Multimeter
{
    public class AmpereMultimeterState : MultimeterState
    {
        public AmpereMultimeterState(MultimeterModel multimeter) : base(multimeter, PhysicalQuantityType.Ampere) { }

        public override void Calculate()
        {
            float measuredValue = _multimeter.MeasurementTarget == null
                ? EmptyMeasuringTargetValue
                : (float)Math.Sqrt(_multimeter.MeasurementTarget.Power / _multimeter.MeasurementTarget.Resistance);

            _multimeter.SetMeasuredValue(measuredValue);
        }

        public override void OnSwitcherScrolled(bool isForward)
        {
            if (isForward)
                _multimeter.SwitchState<ResistanceMultimeterState>();
        }
    }
}