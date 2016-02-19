using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code
{
    class Program
    {
        static void Main()
        {
            JetEngine jet = new JetEngine(600, 500, 5, new List<Propellants> {Propellants.Jet_A}, new List<Oxidisers> {Oxidisers.GOX}, "Rolls-Royce", "RB-201", "100000008", 27000, 12, "88", 0);

            Console.WriteLine(jet);
            var compartments = new Dictionary<uint, GasCompartment>();
            compartments.Add(0, new GasCompartment(20, 15));
            compartments.Add(1, new GasCompartment(20, 10));
            AircraftLighterThanAir baloon = new AircraftLighterThanAir(300, "He", 100000, compartments, new List<Engine>(), 100, "baloon Inc.", "Model-baloon", 700, 40, "88"  );
            Console.WriteLine(baloon);

            Console.WriteLine("\n shifting gas");
            baloon.ShiftGasAft(0, 1, 4.5f);
            Console.WriteLine(baloon);
        }
    }
}