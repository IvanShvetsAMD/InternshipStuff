using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code
{
    class TurbineEngineInstaller : IAddEngines
    {
        public HeavierThanAirAircraft AddTurboshaftengines(HeavierThanAirAircraft aircraft)
        {
            TurbineEngineFactory turbineEngineFactory = TurbineEngineFactory.GeTurbineEngineFactory();

            aircraft.Engines.Add(turbineEngineFactory.TryMakeTurboshaft());
            return aircraft;
        }
    }
}