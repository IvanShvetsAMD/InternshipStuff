using System;
using System.Collections.Generic;

namespace Domain
{
    public class GasCompartment
    {
        public virtual int Id { get; protected set; }
        public virtual float Capacity { get; private set; }
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