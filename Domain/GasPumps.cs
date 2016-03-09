using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class GasPumpManager : ILiftingGasPumpModule
    {
        public void PumpGas(int originCompartment, int destinationCompartment, float volume, List<GasCompartment>  сompartments)
        {
            if (originCompartment == destinationCompartment)
                throw new Exception("No point in shifting gas - the source and the destination match.");
            if (originCompartment >= сompartments.Count || destinationCompartment >= сompartments.Count)
                throw new GasCompartmentsNotFoundException("One or both the compartments are not present in the airship.", originCompartment, destinationCompartment);
            while (true)
            {
                сompartments[originCompartment].CurrentVolume -= 1;
                сompartments[destinationCompartment].CurrentVolume += 1;
                volume -= 1;
                if (сompartments[destinationCompartment].CurrentVolume >=
                    сompartments[destinationCompartment].Capacity)
                {
                    сompartments[originCompartment].CurrentVolume +=
                        сompartments[destinationCompartment].CurrentVolume -
                        сompartments[destinationCompartment].Capacity;
                    сompartments[destinationCompartment].CurrentVolume = сompartments[destinationCompartment].Capacity;
                    break;
                }
                if (volume <= 0)
                {
                    сompartments[originCompartment].CurrentVolume += -1 * volume;
                    сompartments[destinationCompartment].CurrentVolume -= -volume;
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