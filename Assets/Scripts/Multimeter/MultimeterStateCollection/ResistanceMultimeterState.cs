using System;

namespace Multimeter
{
    public class ResistanceMultimeterState : MultimeterState
    {
        public ResistanceMultimeterState(MultimeterModel multimeter) : base(multimeter, PhysicalQuantityType.Resistance) { }

        public override void Calculate()
        {
            float measuredValue = _multimeter.MeasurementTarget == null
                ? EmptyMeasuringTargetValue
                : _multimeter.MeasurementTarget.Resistance;

            _multimeter.SetMeasuredValue(measuredValue);
        }

        public override void OnSwitcherScrolled(bool isForward)
        {
            if (isForward)
                _multimeter.SwitchState<OffMultimeterState>();
            else
                _multimeter.SwitchState<AmpereMultimeterState>();
        }
    }
}