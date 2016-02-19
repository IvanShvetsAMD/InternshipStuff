using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code
{
    class GasCompartment
    {
        public float Capacity { get; private set; }
        public float CurrentVolume { get; set; }

        public override string ToString()
        {
            return String.Format("capacity: {0}, current volume: {1}", Capacity, CurrentVolume);
        }

        public GasCompartment(float capacity, float currentvolume)
        {
            Capacity = capacity;
            CurrentVolume = currentvolume;
        }
    }

    class GasCompartmentComparer : IEqualityComparer<GasCompartment>
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