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
            _capacity = capacity;
            _currentVolume = currentvolume;
        }

        public virtual void AddGas(float delta)
        {
            if (delta >= 0)
            {
                if (_currentVolume + delta >= _capacity)
                    _currentVolume = _capacity;
                else
                {
                    _currentVolume += delta;
                }
            }
        }

        public virtual void RemoveGas(float delta)
        {
            if (delta >= 0)
            {
                if (_currentVolume - delta <= 0)
                    _currentVolume = 0;
                else
                {
                    _currentVolume -= delta;
                }
            }
        }
    }
}