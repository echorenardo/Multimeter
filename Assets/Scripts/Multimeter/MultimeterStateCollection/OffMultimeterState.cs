namespace Multimeter
{
    public class OffMultimeterState : MultimeterState
    {
        public OffMultimeterState(MultimeterModel multimeter) : base(multimeter, PhysicalQuantityType.None) { }

        public override void OnSwitcherScrolled(bool isForward)
        {
            if (isForward)
                _multimeter.SwitchState<ACVoltageMultimeterState>();
            else
                _multimeter.SwitchState<ResistanceMultimeterState>();
        }

        protected override void Calculate()
        {
            _multimeter.SetMeasuredValue(0);
        }
    }
}