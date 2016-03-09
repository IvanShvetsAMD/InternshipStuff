using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public interface ILiftingGasPumpModule
    {
        void PumpGas(int origin, int destination, float volume, List<GasCompartment> compartments );
    }
}
