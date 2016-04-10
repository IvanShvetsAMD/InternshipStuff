namespace Domain
{
    public class Wing : Entity
    {
        private readonly int _fuelCapacity;
        private readonly float _rootThickness;
        private float _wingAngle;
        private FixedWingAircraft _parentAircraft;

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

        public virtual FixedWingAircraft ParentAircraft
        {
            get { return _parentAircraft; }
            set { _parentAircraft = value; }
        }

        public Wing()
        {
            
        }

        public Wing(int fuelcapacity, float rootThickness)
        {
            _parentAircraft = null;
            _fuelCapacity = fuelcapacity;
            _rootThickness = rootThickness;
        }
    }
}