namespace Domain
{
    public class VariableGeometryWing : Wing, IVariableWingActions
    {
        private readonly float _maxBackSweepAngle;
        private readonly float _maxForwardSweepAngle;

        public virtual float MaxBackSweepAngle => _maxBackSweepAngle;

        public virtual float MaxForwardSweepAngle => _maxForwardSweepAngle;

        public virtual void DecreaseAngle(float SweepToAngle)
        {
            if (SweepToAngle < MaxBackSweepAngle)
                WingAngle = SweepToAngle;
            else
            {
                WingAngle = MaxBackSweepAngle;
            }
        }

        public virtual void IncreaseAngle(float SweepToAngle)
        {
            if (SweepToAngle > MaxForwardSweepAngle)
                WingAngle = SweepToAngle;
            else
                WingAngle = MaxForwardSweepAngle;
        }

        public virtual void SweepMaxBack() => WingAngle = MaxBackSweepAngle;

        public virtual void SweepMaxForward() => WingAngle = MaxForwardSweepAngle;

        public VariableGeometryWing()
        {
            
        }

        public VariableGeometryWing(float maxsweepBackAngle, float maxsweepforwardangle, int fuelcapacity, float rootThickness):base(fuelcapacity, rootThickness)
        {
            _maxForwardSweepAngle = maxsweepforwardangle;
            _maxBackSweepAngle = maxsweepBackAngle;
        }
    }
}