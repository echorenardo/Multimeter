using System;
using UnityEngine;

namespace Multimeter
{
    public class ACVoltageMultimeterState : MultimeterState
    {
        public ACVoltageMultimeterState(MultimeterModel multimeter) : base(multimeter, PhysicalQuantityType.ACVoltage) { }

        public override void OnSwitcherScrolled(bool isForward)
        {
            if (isForward)
                _multimeter.SwitchState<DCVoltageMultimeterState>();
            else
                _multimeter.SwitchState<OffMultimeterState>();
        }

        protected override void Calculate()
        {
            float measuredValue = _multimeter.MeasurementTarget == null
                ? EmptyMeasuringTargetValue
                : (float)Math.Sqrt(_multimeter.MeasurementTarget.Power * _multimeter.MeasurementTarget.Resistance);

            _multimeter.SetMeasuredValue(measuredValue);
        }
    }
}