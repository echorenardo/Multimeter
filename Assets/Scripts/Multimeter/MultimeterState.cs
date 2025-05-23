using StateMachine;

namespace Multimeter
{
    public abstract class MultimeterState : State<MultimeterModel>
    {
        protected readonly float EmptyMeasuringTargetValue = 0;

        protected MultimeterModel _multimeter;

        public PhysicalQuantityType PhysicalQuantityType { get; private set; }

        protected MultimeterState(MultimeterModel multimeter, PhysicalQuantityType physicalQuantityType) : base(multimeter)
        {
            _multimeter = multimeter;
            PhysicalQuantityType = physicalQuantityType;
        }

        public override void OnEnter()
        {
            if (_multimeter.MeasurementTarget.Resistance <= 0)
                throw new System.Exception("The resistance must be greater than zero.");

            if (_multimeter.MeasurementTarget.Power <= 0)
                throw new System.Exception("The power must be greater than zero.");

            Calculate();
        }

        public abstract void OnSwitcherScrolled(bool isForward);

        protected abstract void Calculate();
    }
}