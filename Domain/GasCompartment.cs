using System;

namespace Domain
{
    public class GasCompartment : Entity
    {
        public virtual float Capacity { get; protected set; }
        public virtual float CurrentVolume { get; set; }

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