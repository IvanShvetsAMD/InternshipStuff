using System.Collections.Generic;
using Domain;
using Factories;
using Interfaces;

namespace ActionImplementations
{
    public class TurbineEngineInstaller : IAddEngines
    {
        public HeavierThanAirAircraft AddTurboshaftEngines(HeavierThanAirAircraft aircraft)
        {
            TurbineEngineFactory turbineEngineFactory = TurbineEngineFactory.GeTurbineEngineFactory();

            Turboshaft turboshaft = turbineEngineFactory.TryMakeTurboshaft(1, 1, 2, new Generator(), 
                null, 100, 888, 8,
                new List<Propellant> {new Propellant(PropellantsEnum.Jet_A)}, new List<Oxidiser> {new Oxidiser(OxidisersEnum.GOX)}, "no manuf", "model 1",
                "88888888", 2000, 3, 0, OnOff.Stopped, false);
            aircraft.Engines.Add(turboshaft);
            aircraft.Engines.Add(turbineEngineFactory.TryMakeTurboshaft(1, 1, 2, new Generator(),  null, 100, 888, 8,
                new List<Propellant> { new Propellant(PropellantsEnum.Jet_A)}, new List<Oxidiser> { new Oxidiser(OxidisersEnum.GOX) }, "no manuf", "model 1",
                "99999999", 2000, 3, 0, OnOff.Stopped, false));
            return aircraft;
        }
    }
}