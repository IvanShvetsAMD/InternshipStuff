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

        public GasCompartment(float capacity, float currentvolume)
        {
            Capacity = capacity;
            CurrentVolume = currentvolume;
        }
    }
}