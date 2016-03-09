using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class GasPumpManager : ILiftingGasPumpModule
    {
        public void PumpGas(int originCompartment, int destinationCompartment, float volume, List<GasCompartment>  Compartments)
        {
            if (originCompartment == destinationCompartment)
                throw new Exception("No point in shifting gas - the source and the destination match.");
            if (originCompartment >= Compartments.Count || destinationCompartment >= Compartments.Count)
                throw new GasCompartmentsNotFoundException("One or both the compartments are not present in the airship.", originCompartment, destinationCompartment);
            while (true)
            {
                Compartments[originCompartment].CurrentVolume -= 1;
                Compartments[destinationCompartment].CurrentVolume += 1;
                volume -= 1;
                if (Compartments[destinationCompartment].CurrentVolume >=
                    Compartments[destinationCompartment].Capacity)
                {
                    Compartments[originCompartment].CurrentVolume +=
                        Compartments[destinationCompartment].CurrentVolume -
                        Compartments[destinationCompartment].Capacity;
                    Compartments[destinationCompartment].CurrentVolume = Compartments[destinationCompartment].Capacity;
                    break;
                }
                if (volume <= 0)
                {
                    Compartments[originCompartment].CurrentVolume += -1 * volume;
                    Compartments[destinationCompartment].CurrentVolume -= -volume;
                    break;
                }
            }
        }
    }

    public class NonMovableGasManager : ILiftingGasPumpModule
    {
        public void PumpGas(int origin, int destination, float volume, List<GasCompartment> compartments)
        {
            Console.WriteLine("Gas cannot be shifted beacuse the gas compartments are sealed");
        }
    }
}