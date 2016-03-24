using System;

namespace Domain
{
    public class GasCompartment : Entity
    {
        private float _currentVolume;
        private float _capacity;

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

        public override string ToString()
        {
            return String.Format("capacity: {0}, current volume: {1}", Capacity, CurrentVolume);
        }

        [Obsolete]
        protected GasCompartment() { }

        public GasCompartment(float capacity, float currentvolume)
        {
            Capacity = capacity;
            CurrentVolume = currentvolume;
        }
    }
}