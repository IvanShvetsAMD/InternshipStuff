using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public abstract class GasPump : ILiftingGasPumpModule
    {
        public void PumpGas(int originCompartment, int destinationCompartment, float volume, List<GasCompartment> сompartments)
        {
            MainPump(originCompartment, destinationCompartment, volume, сompartments);
        }

        protected abstract void TakePrecautions(int originCompartment, float volume, List<GasCompartment> сompartments);

        public abstract void MainChecks(int originCompartment, int destinationCompartment, List<GasCompartment> сompartments);

        public void MainPump(int originCompartment, int destinationCompartment, float volume, List<GasCompartment> сompartments)
        {
            MainChecks(originCompartment, destinationCompartment, сompartments);
            TakePrecautions(originCompartment, volume, сompartments);
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

    public class GasPumpManager : GasPump
    {
        protected override void TakePrecautions(int originCompartment, float volume, List<GasCompartment> сompartments){}

        public override void MainChecks(int originCompartment, int destinationCompartment, List<GasCompartment> сompartments)
        {
            if (originCompartment == destinationCompartment)
                throw new ArgumentException("No point in shifting gas - the source and the destination match.");
            if (originCompartment >= сompartments.Count || destinationCompartment >= сompartments.Count)
                throw new GasCompartmentsNotFoundException("One or both the compartments are not present in the airship.", originCompartment, destinationCompartment);
            if (originCompartment < 0 || destinationCompartment < 0)
                throw new GasCompartmentsNotFoundException("One or both the compartments are not present in the airship.", originCompartment, destinationCompartment);
        }
    }

    public class SafeGasPumpManager : GasPump
    {
        protected override void TakePrecautions(int originCompartment, float volume, List<GasCompartment> сompartments)
        {
            //safety check
            if ((сompartments[originCompartment].CurrentVolume - volume) < (сompartments[originCompartment].Capacity / 20))
                throw new GasCompartmentsNotFoundException("It is not safe to drain that much gas from one compartment");
        }

        public override void MainChecks(int originCompartment, int destinationCompartment, List<GasCompartment> сompartments)
        {
            if (originCompartment == destinationCompartment)
                throw new ArgumentException("No point in shifting gas - the source and the destination match.");
            if (originCompartment >= сompartments.Count || destinationCompartment >= сompartments.Count)
                throw new GasCompartmentsNotFoundException("One or both the compartments are not present in the airship.", originCompartment, destinationCompartment);
            if (originCompartment < 0 || destinationCompartment < 0)
                throw new GasCompartmentsNotFoundException("One or both the compartments are not present in the airship.", originCompartment, destinationCompartment);
        }
    }

    public class NonMovableGasManager : GasPump
    {
        public new void PumpGas(int origin, int destination, float volume, List<GasCompartment> compartments)
        {
            Console.WriteLine("Gas cannot be shifted beacuse the gas compartments are sealed");
        }

        protected override void TakePrecautions(int originCompartment, float volume, List<GasCompartment> сompartments)
        {
            //none
        }

        public override void MainChecks(int originCompartment, int destinationCompartment, List<GasCompartment> сompartments)
        {
            //none
        }
    }
}