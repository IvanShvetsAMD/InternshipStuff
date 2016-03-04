using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Domain
{
    public class LighterThanAirAircraftProxy : ILighterThanAir
    {
        public uint BallastMass { get; private set; }
        public void DumpBallast(uint mass)
        {
            if (BallastMass > mass)
            {
                BallastMass -= mass;
            }
            else
            {
                BallastMass = 0;
            }
            Console.WriteLine("Ballast dumped ({0} units)", mass);
        }

        public LighterThanAirAircraftProxy(uint ballastmass)
        {
            BallastMass = ballastmass;
        }
        public void ShiftGas(int originCompartment, int destinationCompartment, float Volume)
        {
            Console.WriteLine("The huge task of creating some lighter-that-air aircraft is underway");
            Thread.Sleep(4000);
            LighterThanAirAircraft aircraft = new LighterThanAirAircraft(BallastMass, "He", 400, new List<GasCompartment> {new GasCompartment(200, 200), new GasCompartment(200, 100)}, new List<Engine>(), 300, "Blimp", "StratoCruiser", 8000, 120, "00000488");

            aircraft.ShiftGas(originCompartment, destinationCompartment, Volume);
            Console.WriteLine("Gas shifted");
        }
    }
}