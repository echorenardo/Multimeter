namespace MeasuringTarget
{
    public struct MeasurementTarget : IMeasurementTarget
    {
        public float Resistance { get; private set; }
        public float Power { get; private set; }

        public MeasurementTarget(float resistance, float power)
        {
            Resistance = resistance;
            Power = power;
        }
    }
}