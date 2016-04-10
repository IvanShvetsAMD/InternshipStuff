using System;
using System.Collections.Generic;

namespace Domain
{
    public class GasCompartment : Entity
    {
        private float _capacity;
        private float _currentVolume;
        private LighterThanAirAircraft _parentAircraft;

        public virtual float Capacity
        {
            get { return _capacity; }
            protected set { _capacity = value; }
        }

        public virtual float CurrentVolume
        {
            get { return _currentVolume; }
            set { _currentVolume = value; }
        }

        public virtual LighterThanAirAircraft ParentAircraft
        {
            get { return _parentAircraft; }
            set { _parentAircraft = value; }
        }

        public override string ToString()
        {
            return String.Format("capacity: {0}, current volume: {1}", Capacity, CurrentVolume);
        }

        [Obsolete]
        protected GasCompartment() { }

        public GasCompartment(float capacity, float currentvolume)
        {
            _parentAircraft = null;
            _capacity = capacity;
            _currentVolume = currentvolume;
        }
    }

    public class GasCompartmentComparer : IEqualityComparer<GasCompartment>
    {
        public bool Equals(GasCompartment x, GasCompartment y)
        {
            return NearlyEqual(x.CurrentVolume, y.CurrentVolume, 0.0001f) && NearlyEqual(x.Capacity, y.Capacity, 0.0001f);
        }

        public int GetHashCode(GasCompartment obj)
        {
            return (int)obj?.ToString().GetHashCode();
        }

        public bool NearlyEqual(float a, float b, float epsilon)
        {
            float absA = Math.Abs(a);
            float absB = Math.Abs(b);
            float diff = Math.Abs(a - b);

            if (a == b)
                return true;
            if (a == 0 || b == 0 || diff < float.Epsilon)
                return diff < epsilon;
            return diff/(absA + absB) < epsilon;
        }

        public GasCompartmentComparer() {}
    }
}