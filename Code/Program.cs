﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Domain;
using Factories;
using Infrastructure;
using LoggerService;
using Repository.Implemetations;
using Repository.Interfaces;
using static System.String;

namespace PresentationCode
{
    public delegate void LogChangedDelegate(LogEventArgs logEventArgs);
    class Program
    {
        //[STAThread]
        static void Main()
        {
            //Thread t = new Thread(new ThreadStart(StartNewStaThread));
            //t.Start();

            Logger log = Logger.GetLogger();
            AviationAdministration FAA = AviationAdministration.GetInstance();
            NTSB NTSB = new NTSB();

            #region Side tasks (testing things)

            JetEngine jet1 = new JetEngine(600, 500, 5, new List<Propellant> { new Propellant(PropellantsEnum.Jet_A) },
                new List<Oxidiser> { new Oxidiser(OxidisersEnum.GOX) }, "Rolls-Royce", "RB-201", "100000008", 27000, 12, null, 0, OnOff.Stopped);
            JetEngine jet2 = new JetEngine(600, 500, 5, new List<Propellant> { new Propellant(PropellantsEnum.Jet_A) },
                new List<Oxidiser> { new Oxidiser(OxidisersEnum.GOX) }, "Rolls-Royce", "RB-201", "888888888", 27000, 12, null, 0, OnOff.Running);


            var compartments = new List<GasCompartment>
            {
                new GasCompartment(20, 15),
                new GasCompartment(20, 10),
                new GasCompartment(20, 15),
                new GasCompartment(15, 10)
            };

            LighterThanAirAircraft baloon = new LighterThanAirAircraft(new SafeGasPumpManager(), 300, "He", compartments,
                new List<Engine> { jet1, jet2 }, 100, "baloon Inc.", "Model-baloon", 700, 40, "88");
            Console.WriteLine(baloon);
            ////Console.WriteLine("\n\nComparing gas compartments:");

            //baloon.ShiftGas(5, 65, 5);


            //Console.WriteLine("\n shifting gas");
            //try
            //{
            //    baloon.ShiftGas(0, 1, 14.5f);
            //    //baloon.ShiftGas(0, 0, 4.5f);
            //    //baloon.ShiftGas(0, 4, -4.5f);
            //}
            //catch (GasCompartmentsNotFoundException e) when (e.OriginCompartment == e.DestinationCompartment)
            //{
            //    Console.WriteLine($"\n{e.Message}.\n", e.Message);
            //}
            //catch (GasCompartmentsNotFoundException e)
            //{
            //    Console.WriteLine($"\n{e.Message} (origin: {e.OriginCompartment}, destination: {e.DestinationCompartment}).\n");
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

            String[] ox = Enum.GetNames(typeof(OxidisersEnum));
            foreach (var s in ox)
            {
                Console.WriteLine(s);
            }

            ServiceLocator.RegisterAll();
            //HeavierThanAirAircraftFactory factory = ServiceLocator.Get<HeavierThanAirAircraftFactory>();

            #region factories and cultures

            //RotorCraft rotorCraft = factory.TryMakeRotorCraft("00000000", new List<RotorBlade>(), "standart TEST rotor",
            //    42, 73, "TEST manufacturer", 4242);
            ////Console.WriteLine(rotorCraft);
            //FAA.RegisterAircraft(new List<AircraftRegistration>
            //    {
            //        new AircraftRegistration(rotorCraft, true),
            //        new AircraftRegistration(rotorCraft, false)
            //});

            #region 

            //Thread t = new Thread(new ThreadStart(StartNewStaThread));
            //t.Start();


            //Thread.Sleep(4000);

            //Console.WriteLine("\n\n\n");
            //RotorCraft rotorCraft2 = factory.TryMakeRotorCraft("000000002", new List<RotorBlade>(),
            //    "standart TEST rotor2",
            //    42, 73, "TEST manufacturer2", 4242);
            //Console.WriteLine(rotorCraft2);

            //log.ExportToFile();
            //log.FileName = "NumberTWO";
            //log.ExportToFile();

            //log.AddToLog(log.FindInLog("000000002").ToString());
            //log.AddToLogWithOffset("Testing the offset method");

            //log.AddToLog("sdasdsadsadad");
            //Thread.Sleep(2000);
            //Console.WriteLine(log.CalculatePostTimeDifference());





            //switch (Console.ReadLine().ToUpper())
            //{
            //    case "US":
            //        Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            //        break;
            //    case "UK":
            //        Thread.CurrentThread.CurrentCulture = new CultureInfo("en-GB");
            //        break;
            //    default:
            //        Console.WriteLine("wrong answer)");
            //        break;
            //}

            //switch (Thread.CurrentThread.CurrentCulture.ToString())
            //{
            //    case "en-US":
            //        Console.WriteLine("honor, behavior...");
            //        Console.WriteLine(TimeZone.CurrentTimeZone.StandardName);
            //        break;
            //    case "en-GB":
            //        Console.WriteLine("colour, monetisation...");
            //        Console.WriteLine(TimeZone.CurrentTimeZone.StandardName);
            //        break;
            //}

            #endregion


            #endregion

            #region Decorator

            //var turbineEngineFactory = TurbineEngineFactory.GeTurbineEngineFactory();

            //var turboFan = new Turbofan();

            //if (turbineEngineFactory.TryMakeTurbofan(4, 3, new Generator(),
            //    new List<Spool>(), 600, 500, 5, new List<Propellants> { Propellants.Jet_A },
            //    new List<Oxidisers> { Oxidisers.GOX }, "Rolls-Royce", "RB-201", "100000008", 27000, 88, 0, OnOff.Stopped,
            //    out turboFan))
            //{
            //    Console.WriteLine();
            //    Console.WriteLine(turboFan);
            //}
            //else
            //{
            //    Console.WriteLine();
            //    Console.WriteLine("No engine could be created");
            //}


            //ReheatDecorator engineDecorator = new ReheatDecorator(turboFan);
            //engineDecorator.Decorate(new ReheatChamber(1.5));
            //engineDecorator.Reheat.Engage();
            //Console.WriteLine("\n\n\n\n");
            //Console.WriteLine(engineDecorator);

            //DumpAndBurnDecorator decorator2 = new DumpAndBurnDecorator(engineDecorator);
            //decorator2.Decorate(new FuelDumper(2));
            //decorator2.DumpandBurn.Engage();
            //Console.WriteLine("\n\n\n\n");
            //Console.WriteLine(decorator2);

            //#endregion

            //#region Proxy

            //Console.WriteLine("\n\n\n\n");
            //LighterThanAirAircraftProxy proxy = new LighterThanAirAircraftProxy(300);
            //Stopwatch performanceStopwatch = new Stopwatch();
            //performanceStopwatch.Start();
            //proxy.DumpBallast(100);
            //performanceStopwatch.Stop();
            //Console.WriteLine("Ballast dumping took aprox. {0} ticks", performanceStopwatch.ElapsedTicks);

            //Console.WriteLine("\n\n");
            //performanceStopwatch.Restart();
            //proxy.ShiftGas(0, 1, 50);
            //performanceStopwatch.Start();
            //Console.WriteLine("Creating a new object and shifting gas took aprox {0} ticks", performanceStopwatch.ElapsedTicks);

            #endregion

            //rotorCraft.IsOperational = false;
            //Console.WriteLine(rotorCraft);



            var lighterThanAirAircraftRepository = ServiceLocator.Get<ILighterThanAirAircraftRepository>();

            lighterThanAirAircraftRepository.Save(baloon);

            var gasCompartmentRepository = ServiceLocator.Get<IGasCompartmentRepository>();

            gasCompartmentRepository.Save(new GasCompartment(7373, 4242, null));


           // var generatorRepository = ServiceLocator.Get<IGeneratorRepository>();
            //generatorRepository.Save(new Generator(88, 88, new TurbineEngine()));

            LighterThanAirAircraft testload = lighterThanAirAircraftRepository.LoadEntity<LighterThanAirAircraft>(1);

            Console.WriteLine(testload);
            log.Dispose();
        }

        [STAThread]
        private static void StartNewStaThread()
        {
            Application.Run(LogForm.GetLogForm());
        }
    }
}