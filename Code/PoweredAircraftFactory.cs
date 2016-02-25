using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Code
{
    class HeavierThanAirAircraftFactory
    {
        static readonly Lazy<HeavierThanAirAircraftFactory> LazyInstance = new Lazy<HeavierThanAirAircraftFactory>(
            () => new HeavierThanAirAircraftFactory(), LazyThreadSafetyMode.ExecutionAndPublication);
        
        static HeavierThanAirAircraftFactory() { }
        private HeavierThanAirAircraftFactory() { }

        public static HeavierThanAirAircraftFactory GetPoweredAircraftFactory() => LazyInstance.Value;

        public RotorCraft MakeHeavierThanAirTurbofanAircraft(string serialnumber, List<RotorBlade> rotorblades, string rotortype = "standart rotor", int numberofrotors = 1, int fuelcapacity = 0, string manufacturer = "generic aircraft maker", int maxTOweight = 1000)
        {
            if (string.IsNullOrWhiteSpace(serialnumber))
                throw new ArgumentException("No serial number provided");
            if (rotorblades == null)
                throw new ArgumentNullException(nameof(rotorblades), "No rotor(s) provided");

            Turbofan tj;
            if (TurbineEngineFactory.GeTurbineEngineFactory()
                    .TryMakeTurbofan(4, 3, new Dictionary<Generator, double>(new GeneratorComparer()),
                        new List<Spool>(), 600, 500, 5, new List<Propellants> {Propellants.Jet_A},
                        new List<Oxidisers> {Oxidisers.GOX}, "Rolls-Royce", "RB-201", "100000008", 27000, 88, 0,
                        OnOff.Stopped, out tj))
            {
                return new RotorCraft(numberofrotors, rotorblades, rotortype, new List<Engine> {tj}, fuelcapacity, manufacturer, "generic model", maxTOweight, 0, serialnumber);
            }
            return new RotorCraft(numberofrotors, rotorblades, rotortype, new List<Engine> { tj }, fuelcapacity, manufacturer, "generic model", maxTOweight, 0, serialnumber);
        }
    }
}