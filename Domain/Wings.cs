namespace Domain
{
    public class Wing : Entity
    {
        private readonly int _fuelCapacity;
        private readonly float _rootThickness;
        private float _wingAngle;



        public virtual int FuelCapacity
        {
            get { return _fuelCapacity; }
        }

        public virtual float RootThickness
        {
            get { return _rootThickness; }
        }

        public virtual float WingAngle
        {
            get { return _wingAngle; }
            protected set { _wingAngle = value; }
        }
        
        public Wing()
        {
            
        }

        public Wing(int fuelcapacity, float rootThickness)
        {
            _fuelCapacity = fuelcapacity;
            _rootThickness = rootThickness;
        }
    }

    public class VariableGeometryWing : Wing, IVariableWingActions
    {
        private readonly float _maxBackSweepAngle;
        private readonly float _maxForwardSweepAngle;

        public virtual float MaxBackSweepAngle
        {
            get { return _maxBackSweepAngle; }
        }

        public virtual float MaxForwardSweepAngle
        {
            get { return _maxForwardSweepAngle; }
        }

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