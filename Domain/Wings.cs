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

        public Wing(int fuelcapacity, float rootThickness)
        {
            _fuelCapacity = fuelcapacity;
            _rootThickness = rootThickness;
        }
    }
}