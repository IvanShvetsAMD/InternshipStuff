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

            //JetEngine jet1 = new JetEngine(600, 500, 5, new List<Propellants> { Propellants.Jet_A },
            //    new List<Oxidisers> { Oxidisers.GOX }, "Rolls-Royce", "RB-201", "100000008", 27000, 12, "88", 0, OnOff.Stopped);
            //JetEngine jet2 = new JetEngine(600, 500, 5, new List<Propellants> { Propellants.Jet_A },
            //    new List<Oxidisers> { Oxidisers.GOX }, "Rolls-Royce", "RB-201", "888888888", 27000, 12, "88", 0, OnOff.Running);


            //var compartments = new List<GasCompartment>
            //{
            //    new GasCompartment(20, 15),
            //    new GasCompartment(20, 10),
            //    new GasCompartment(20, 15),
            //    new GasCompartment(15, 10)
            //};

            //LighterThanAirAircraft baloon = new LighterThanAirAircraft(new SafeGasPumpManager(), 300, "He", compartments,
            //    new List<Engine> { jet1, jet2 }, 100, "baloon Inc.", "Model-baloon", 700, 40, "88");
            //Console.WriteLine(baloon);
            //////Console.WriteLine("\n\nComparing gas compartments:");
             
            //baloon.ShiftGas(5,65,5);


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
            HeavierThanAirAircraftFactory factory = ServiceLocator.Get<HeavierThanAirAircraftFactory>();

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
            
            
            //gas compartment
            var gasCompartmentRepository = ServiceLocator.Get<IGasCompartmentRepository>();
            gasCompartmentRepository.Save(new GasCompartment(400, 380));

            //generator
            var generatorRepository = ServiceLocator.Get<IGeneratorRepository>();
            generatorRepository.Save(new Generator(42, 73));

            //wing
            var wingRepository = ServiceLocator.Get<IWingRepository>();
            wingRepository.Save(new Wing(42, 73));

            ////VariableGeometryWing
            var VGWRepository = ServiceLocator.Get<IVariableGeometryWingRepository>();
            VGWRepository.Save(new VariableGeometryWing(42, 73, 42, 73));

            //engine
            var engineRepository = ServiceLocator.Get<IEngineRepository>();
            //it's an abstract class

            //piston engine
            var pistonEngineRepository = ServiceLocator.Get<IPistonEngineRepository>();
            pistonEngineRepository.Save(new PistonEngine(42, 73, "42", "73", "42", 73, 42, new FixedWingAircraft(), 42, OnOff.Stopped));

            //jet engine
            var jetEngineRepository = ServiceLocator.Get<IJetEngineRepository>();
            jetEngineRepository.Save(new JetEngine(42, 73, 42, null, null, "42", "73", "42", 73, 42, new FixedWingAircraft(), 42, OnOff.Stopped));

            //rocket engine
            var rocketEngineRepository = ServiceLocator.Get<IRocketEngineRepository>();
            rocketEngineRepository.Save(new RocketEngine(true, "42", 42, 73, 42, null, null, "42", "73", "42", 73, 42, new FixedWingAircraft(), 42, OnOff.Stopped));

            //solid fuel rocket engine
            var solidFuelRocketEngineRepository = ServiceLocator.Get<ISolidFuelRocketEngineRepository>();
            solidFuelRocketEngineRepository.Save(new SolidFuelRocketEngine(true, "42", 42, 73, 42, null, null, "42", "73", "42", 73, 42, new FixedWingAircraft(), 42, OnOff.Stopped));

            //turbine engine
            var turbineEngineRepository = ServiceLocator.Get<ITurbineEngineRepository>();
            turbineEngineRepository.Save(new TurbineEngine(true, 42, null, null, 42, 73, 42, null, null, "42", "73", "42", 73, 42, new FixedWingAircraft(), 42, OnOff.Stopped));

            //ramjet
            var ramjetRepository = ServiceLocator.Get<IRamjetRepository>();
            ramjetRepository.Save(new Ramjet(true, 42, 73, 42, null, null, "42", "73", "42", 73, 42, new FixedWingAircraft(), 42, OnOff.Stopped));

            //turbofan
            var turbofanRepository = ServiceLocator.Get<ITurbofanRepository>();
            turbofanRepository.Save(new Turbofan(42, true, true, 42, null, null, 73, 42, 73, null, null, "42", "73", "42", 73, 42, new FixedWingAircraft(), 42, OnOff.Stopped));

            //turboshaft
            var turboshaftRepository = ServiceLocator.Get<ITurboshaftRepository>();
            turboshaftRepository.Save(new Turboshaft(42, 73, true, 42, null, null, 73, 42, 73, null, null, "42", "73", "42", 73, 42, new FixedWingAircraft(), 42, OnOff.Stopped));

            //turbojet
            var turbojetRepository = ServiceLocator.Get<ITurbojetRepository>();
            turbojetRepository.Save(new Turbojet(true, 42, null, null, 73, 42, 73, null, null, "42", "73", "42", 73, 42, new FixedWingAircraft(), 42, OnOff.Stopped));

            //aircraft
            var aircraftRepository = ServiceLocator.Get<IAircraftRepository>();
            //it's an abstarct class

            //powered aircraft
            var poweredAircraftRepository = ServiceLocator.Get<IPoweredAircraftRepository>();
            poweredAircraftRepository.Save(new PoweredAircraft(new List<Engine>(), 42, "42", "73", 42, 73, "42"));

            //lighter than air aircraft
            var lighterThanAirAircraftRepository = ServiceLocator.Get<ILighterThanAirAircraftRepository>();
            lighterThanAirAircraftRepository.Save(new LighterThanAirAircraft(null, 42, "He", new List<GasCompartment>(), null, 73, "42", "73", 42, 73, "42"));

            //heavier than air aircraft
            var heavierThanAirAircraftRepository = ServiceLocator.Get<IHeavierThanAirAircraftRepository>();
            heavierThanAirAircraftRepository.Save(new HeavierThanAirAircraft(new List<Engine>(), 42, "42", "73", 42, 73, "42"));

            //fixed wing aircraft
            var fixedWingAricraftRepository = ServiceLocator.Get<IFixedWingAircraftRepository>();
            fixedWingAricraftRepository.Save(new FixedWingAircraft(new List<Wing>(), 42, 73, null, 42, "42", "73", 42, 73, "42"));

            //rotorcraft
            var rotorcraftRepository = ServiceLocator.Get<IRotorCraftRepository>();
            rotorcraftRepository.Save(new RotorCraft(42, new List<RotorBlade>(), "73", new List<Engine>(), 42, "42", "73", 42, 73, "42"));

            //propellant
            var propellantRepository = ServiceLocator.Get<IPropellantRepository>();
            propellantRepository.Save(new Propellant(PropellantsEnum.MonoMethylHydrazine));

            //oxidiser
            var oxidiserRepository = ServiceLocator.Get<IOxidiserRepository>();
            oxidiserRepository.Save(new Oxidiser(OxidisersEnum.DinitrogenTetroxide));

            //blade
            var bladeRepository = ServiceLocator.Get<IBladeRepository>();
            //it's an abstract class

            //turbine blade
            var turbineBladeRepository = ServiceLocator.Get<ITurbineBladeRepository>();
            turbineBladeRepository.Save(new TurbineBlade(42, true, 42, 73, "42"));

            //rotor blade
            var rotorBladeRepository = ServiceLocator.Get<IRotorBladeRepository>();
            rotorBladeRepository.Save(new RotorBlade(true, 42, 73, "42"));

            //spool
            var spoolRepository = ServiceLocator.Get<ISpoolRepository>();
            spoolRepository.Save(new Spool(null, "42"));


            log.Dispose();
        }

        [STAThread]
        private static void StartNewStaThread()
        {
            Application.Run(LogForm.GetLogForm());
        }
    }
}