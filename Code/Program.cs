using System;
using System.Collections.Generic;
using Domain;
using Factories;
using Infrastructure;

namespace PresentationCode
{
    class Program
    {
        static void Main()
        {

            #region 

            //JetEngine jet1 = new JetEngine(600, 500, 5, new List<Propellants> { Propellants.Jet_A },
            //    new List<Oxidisers> { Oxidisers.GOX }, "Rolls-Royce", "RB-201", "100000008", 27000, 12, "88", 0, OnOff.Stopped);
            ////JetEngine jet2 = new JetEngine(600, 500, 5, new List<Propellants> { Propellants.Jet_A },
            ////    new List<Oxidisers> { Oxidisers.GOX }, "Rolls-Royce", "RB-201", "888888888", 27000, 12, "88", 0, OnOff.Running);


            //var compartments = new Dictionary<uint, GasCompartment>
            //{
            //    {0, new GasCompartment(20, 15)},
            //    {1, new GasCompartment(20, 10)},
            //    {2, new GasCompartment(20, 15)},
            //    {3, new GasCompartment(15, 10)} };

            //LighterThanAirAircraft baloon = new LighterThanAirAircraft(300, "He", 100000, compartments,
            //    new List<Engine> { jet1, jet2 }, 100, "baloon Inc.", "Model-baloon", 700, 40, "88");
            //Console.WriteLine(baloon);
            //Console.WriteLine("\n\nComparing gas compartments:");


            //Console.WriteLine("\n shifting gas");
            //try
            //{
            //    baloon.ShiftGas(0, 1, 4.5f);
            //    //baloon.ShiftGas(0, 0, 4.5f);
            //    //baloon.ShiftGas(0, 4, -4.5f);
            //}
            //catch (GasCompartmentsNotFoundException e)
            //{
            //    Console.WriteLine("\n{0} (origin: {1}, destination: {2}).\n", e.Message, e.OriginCompartment,
            //        e.DestinationCompartment);
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e.Message);
            //    Debug.WriteLine(e.Message);
            //}
            //finally
            //{
            //    Console.WriteLine("An attempt was made to shift lifting gas\n");
            //}
            //Console.WriteLine(baloon);

            //Console.WriteLine();
            //Console.WriteLine("Attemting to stop an engine");
            //try
            //{
            //    baloon.StopEngine(baloon.Engines[0]);
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e.Message);
            //    Console.WriteLine(e.InnerException?.Message ?? "no inner exception");
            //}

            #endregion





            ////Turbofan tb = new Turbofan(3, false, true, 3,new Dictionary<Generator, double>(),  new List<Spool>(), 600, 500, 5, new List<Propellants> { Propellants.Jet_A }, new List<Oxidisers> { Oxidisers.GOX }, "Rolls-Royce", "RB-201", "100000008", 27000, 12, "88", 0);
            //Turbofan tb = new Turbofan(3, false, true, 3, new Dictionary<Generator, double>(new GeneratorComparer()),
            //    new List<Spool>(), 600, 500, 5, new List<Propellants> {Propellants.Jet_A},
            //    new List<Oxidisers> {Oxidisers.GOX}, "Rolls-Royce", "RB-201", "100000008", 27000, 12, "88", 0);

            //tb.Gens.Add(new Generator(4, 4), 1);
            //tb.Gens.Add(new Generator(12, 36), 3);

            //Console.WriteLine(tb.Gens.ContainsKey(new Generator(4, 4)));

            String[] ox = Enum.GetNames(typeof(Oxidisers));
            foreach (var s in ox)
            {
                Console.WriteLine(s);
            }

            //var tjf = TurbineEngineFactory.GeTurbineEngineFactory();

            //var tj = new Turbofan();

            //if (tjf.TryMakeTurbofan(4, 3, new Dictionary<Generator, double>(new GeneratorComparer()),
            //    new List<Spool>(), 600, 500, 5, new List<Propellants> { Propellants.Jet_A },
            //    new List<Oxidisers> { Oxidisers.GOX }, "Rolls-Royce", "RB-201", "100000008", 27000, 88, 0, OnOff.Stopped, out tj))
            //{
            //    Console.WriteLine();
            //    Console.WriteLine(tj);
            //}
            //else
            //{
            //    Console.WriteLine();
            //    Console.WriteLine("No engine could be created");
            //}


            //HeavierThanAirAircraftFactory htaaf = HeavierThanAirAircraftFactory.GetHeavierThanAirAircraftFactory();
            //Console.WriteLine("\n\n\n");
            //try
            //{
            //    Aircraft plane = htaaf.MakeFixedWingAircraft(new List<Wing> {new Wing(23, 120) }, "1000008", 400, 150, 160000);
            //    Console.WriteLine("\n\n\n");
            //    Console.WriteLine(plane);
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e);
            //}


            ServiceLocator.RegisterAll();
            HeavierThanAirAircraftFactory factory = ServiceLocator.Get<HeavierThanAirAircraftFactory>();

            Console.WriteLine(factory.TryMakeRotorCraft("00000000", new List<RotorBlade>(), "standart TEST rotor", 42, 73, "TEST manufacturer", 4242));
        }
    }
}