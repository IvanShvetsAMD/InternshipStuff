namespace Domain
{
    public class Wing
    {
        public int FuelCapacity { get; private set; }
        public float RootThickness { get; private set; }
        public float WingAngle { get; protected set; }

        public Wing(int fuelcapacity, float rootThickness)
        {
            FuelCapacity = fuelcapacity;
            RootThickness = rootThickness;
        }
    }

    public class VariableGeometryWing : Wing, IVariableWingActions
    {
        public float MaxBackSweepAngle { get; private set; }
        public float MaxForwardSweepAngle { get; private set; }
        public void DecreaseAngle(float SweepToAngle)
        {
            if (SweepToAngle < MaxBackSweepAngle)
                WingAngle = SweepToAngle;
            else
            {
                WingAngle = MaxBackSweepAngle;
            }
        }

        public void IncreaseAngle(float SweepToAngle)
        {
            if (SweepToAngle > MaxForwardSweepAngle)
                WingAngle = SweepToAngle;
            else
                WingAngle = MaxForwardSweepAngle;
        }

        public void SweepMaxBack() => WingAngle = MaxBackSweepAngle;

        public void SweepMaxForward() => WingAngle = MaxForwardSweepAngle;

        public VariableGeometryWing(float maxsweepBackAngle, float maxsweepforwardangle, int fuelcapacity, float rootThickness):base(fuelcapacity, rootThickness)
        {
            MaxForwardSweepAngle = maxsweepforwardangle;
            MaxBackSweepAngle = maxsweepBackAngle;
        }
    }
}