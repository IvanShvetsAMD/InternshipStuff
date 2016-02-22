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
            #region 

            JetEngine jet1 = new JetEngine(600, 500, 5, new List<Propellants> { Propellants.Jet_A },
                new List<Oxidisers> { Oxidisers.GOX }, "Rolls-Royce", "RB-201", "100000008", 27000, 12, "88", 0);
            JetEngine jet2 = new JetEngine(600, 500, 5, new List<Propellants> { Propellants.Jet_A },
                new List<Oxidisers> { Oxidisers.GOX }, "Rolls-Royce", "RB-201", "888888888", 27000, 12, "88", 0);


            var compartments = new Dictionary<uint, GasCompartment>
            {
                {0, new GasCompartment(20, 15)},
                {1, new GasCompartment(20, 10)},
                {2, new GasCompartment(20, 15)},
                {3, new GasCompartment(15, 10)} };

            AircraftLighterThanAir baloon = new AircraftLighterThanAir(300, "He", 100000, compartments,
                new List<Engine> { jet1, jet2 }, 100, "baloon Inc.", "Model-baloon", 700, 40, "88");
            Console.WriteLine(baloon);
            Console.WriteLine("\n\nComparing gas compartments:");
            Console.WriteLine("\t{0}");

            Console.WriteLine("\n shifting gas");
            try
            {
                baloon.ShiftGas(0, 1, -4.5f);
            }
            catch (GasCompartmentsNotFoundException e)
            {
                Console.WriteLine(e);
            }
            Console.WriteLine(baloon);


            ////Turbofan tb = new Turbofan(3, false, true, 3,new Dictionary<Generator, double>(),  new List<Spool>(), 600, 500, 5, new List<Propellants> { Propellants.Jet_A }, new List<Oxidisers> { Oxidisers.GOX }, "Rolls-Royce", "RB-201", "100000008", 27000, 12, "88", 0);
            //Turbofan tb = new Turbofan(3, false, true, 3, new Dictionary<Generator, double>(new GeneratorComparer()),
            //    new List<Spool>(), 600, 500, 5, new List<Propellants> {Propellants.Jet_A},
            //    new List<Oxidisers> {Oxidisers.GOX}, "Rolls-Royce", "RB-201", "100000008", 27000, 12, "88", 0);

            //tb.Gens.Add(new Generator(4, 4), 1);
            //tb.Gens.Add(new Generator(12, 36), 3);

            //Console.WriteLine(tb.Gens.ContainsKey(new Generator(4, 4)));

            //String[] ox = Enum.GetNames(typeof (Oxidisers));
            //foreach (var s in ox)
            //{
            //    Console.WriteLine(s);
            //}

            #endregion
        }
    }
}