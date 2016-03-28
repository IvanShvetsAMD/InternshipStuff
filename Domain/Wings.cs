using System.ComponentModel.Design;

namespace Domain
{
    public class Wing : Entity
    {
        private readonly int _fuelCapacity;
        private readonly float _rootThickness;
        private float _wingAngle;
        private FixedWingAircraft _parentfFixedWingAircraft;


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

        public virtual FixedWingAircraft ParentfFixedWingAircraft
        {
            get { return _parentfFixedWingAircraft; }
            protected set { _parentfFixedWingAircraft = value; }
        }

        public Wing(int fuelcapacity, float rootThickness, FixedWingAircraft parentfFixedWingAircraft = null)
        {
            _fuelCapacity = fuelcapacity;
            _rootThickness = rootThickness;
            _parentfFixedWingAircraft = parentfFixedWingAircraft;
        }
    }
}