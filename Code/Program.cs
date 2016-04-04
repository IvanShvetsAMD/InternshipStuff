using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Domain;
using Domain.Dto;
using Factories;
using HibernatingRhinos.Profiler.Appender.NHibernate;
using Infrastructure;
using LoggerService;
using Repository.Interfaces;

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

            NHibernateProfiler.Initialize();


            //aircraft registry
            var aircraftRegistryRepository = ServiceLocator.Get<IAircraftRegistryRepository>();
            aircraftRegistryRepository.Save(new AircraftRegistry("VH-HYR", false, new DateTime(1996, 10, 10), "622"));

            //gas compartment
            var gasCompartmentRepository = ServiceLocator.Get<IGasCompartmentRepository>();
            gasCompartmentRepository.Save(new GasCompartment(4000, 3800));

            //generator
            var generatorRepository = ServiceLocator.Get<IGeneratorRepository>();
            generatorRepository.Save(new Generator(42, 73));

            //wing
            var wingRepository = ServiceLocator.Get<IWingRepository>();
            wingRepository.Save(new Wing(42, 73));

            ////VariableGeometryWing
            var VGWRepository = ServiceLocator.Get<IVariableGeometryWingRepository>();
            VGWRepository.Save(new VariableGeometryWing(42, 73, 42, 73));

            //aircraft
            var aircraftRepository = ServiceLocator.Get<IAircraftRepository>();
            //it's an abstarct class

            //powered aircraft
            var poweredAircraftRepository = ServiceLocator.Get<IPoweredAircraftRepository>();
            poweredAircraftRepository.Save(new PoweredAircraft(null, 42, "42", "73", 42, 73, "622"));
            poweredAircraftRepository.Save(new PoweredAircraft(null, 42, "42", "73", 42, 73, "888"));

            //lighter than air aircraft
            var lighterThanAirAircraftRepository = ServiceLocator.Get<ILighterThanAirAircraftRepository>();
            lighterThanAirAircraftRepository.Save(new LighterThanAirAircraft(null, 42, "He", new List<GasCompartment>(), new List<Engine>(), 73, "42", "73", 42, 73, "741"));

            //heavier than air aircraft
            var heavierThanAirAircraftRepository = ServiceLocator.Get<IHeavierThanAirAircraftRepository>();
            heavierThanAirAircraftRepository.Save(new HeavierThanAirAircraft(new List<Engine>(), 42, "42", "73", 42, 73, "2849"));

            //fixed wing aircraft
            var fixedWingAricraftRepository = ServiceLocator.Get<IFixedWingAircraftRepository>();
            fixedWingAricraftRepository.Save(new FixedWingAircraft(new List<Wing>(), 42, 73, new List<Engine>(), 42, "42", "73", 42, 73, "666"));

            //rotorcraft
            var rotorcraftRepository = ServiceLocator.Get<IRotorCraftRepository>();
            rotorcraftRepository.Save(new RotorCraft(42, new List<RotorBlade>(), "73", new List<Engine>(), 42, "42", "73", 42, 73, "19000130"));

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
            turbineBladeRepository.Save(new TurbineBlade(1000, true, 18, 12, "High temp alloy"));

            //rotor blade
            var rotorBladeRepository = ServiceLocator.Get<IRotorBladeRepository>();
            rotorBladeRepository.Save(new RotorBlade(true, 42, 73, "42"));

            //spool
            var spoolRepository = ServiceLocator.Get<ISpoolRepository>();
            spoolRepository.Save(new Spool(new List<TurbineBlade>(), "42"));

            //engine
            var engineRepository = ServiceLocator.Get<IEngineRepository>();
            //it's an abstract class

            //piston engine
            var pistonEngineRepository = ServiceLocator.Get<IPistonEngineRepository>();
            pistonEngineRepository.Save(new PistonEngine(42, 73, "42", "73", "42", 73, 42, null, 73, OnOff.Stopped));

            //jet engine
            var jetEngineRepository = ServiceLocator.Get<IJetEngineRepository>();
            jetEngineRepository.Save(new JetEngine(42, 73, 42, null, null, "42", "73", "42", 73, 42, null, 42, OnOff.Stopped));

            //rocket engine
            var rocketEngineRepository = ServiceLocator.Get<IRocketEngineRepository>();
            rocketEngineRepository.Save(new RocketEngine(true, "42", 42, 73, 42, null, null, "42", "73", "42", 73, 42, null, 42, OnOff.Stopped));

            //solid fuel rocket engine
            var solidFuelRocketEngineRepository = ServiceLocator.Get<ISolidFuelRocketEngineRepository>();
            solidFuelRocketEngineRepository.Save(new SolidFuelRocketEngine(true, "42", 42, 73, 42, null, null, "42", "73", "42", 73, 42, null, 73, OnOff.Stopped));

            //turbine engine
            var turbineEngineRepository = ServiceLocator.Get<ITurbineEngineRepository>();
            turbineEngineRepository.Save(new TurbineEngine(true, 42, null, null, 42, 73, 42, null, null, "42", "73", "42", 73, 42, null, 42, OnOff.Stopped));

            //ramjet
            var ramjetRepository = ServiceLocator.Get<IRamjetRepository>();
            ramjetRepository.Save(new Ramjet(true, 42, 73, 42, null, null, "42", "73", "42", 73, 42, null, 42, OnOff.Stopped));

            //turbofan
            var turbofanRepository = ServiceLocator.Get<ITurbofanRepository>();
            turbofanRepository.Save(new Turbofan(42, true, true, 42, null, null, 73, 42, 73, null, null, "42", "73", "42", 73, 42, null, 42, OnOff.Stopped));

            //turboshaft
            var turboshaftRepository = ServiceLocator.Get<ITurboshaftRepository>();
            turboshaftRepository.Save(new Turboshaft(42, 73, true, 42, null, null, 73, 42, 73, null, null, "42", "73", "42", 73, 42, null, 42, OnOff.Stopped));

            //turbojet
            var turbojetRepository = ServiceLocator.Get<ITurbojetRepository>();
            turbojetRepository.Save(new Turbojet(true, 42, null, null, 73, 42, 73, null, null, "42", "73", "42", 73, 42, null, 42, OnOff.Stopped));




            ////testing double session use
            //var testSpool = turbojetRepository.LoadEntity<Spool>(159159);

            //var testTurbojet = turbojetRepository.LoadEntity<Turbojet>(120128);

            //testSpool.ParentEngine = testTurbojet;

            //testTurbojet.Spools.Add(testSpool);

            //turbojetRepository.Save(testTurbojet);

            ////turbojetRepository.Delete(testTurbojet);

            List<Spool> spools = new List<Spool>();
            spools.Add(new Spool(null, "Fan"));
            spools.Add(new Spool(null, "IP spool"));
            spools.Add(new Spool(null, "LP spool"));
            spools.Add(new Spool(null, "HP spool"));

            List<TurbineBlade> blades = new List<TurbineBlade>();
            for (int i = 0; i < 10; i++)
            {
                TurbineBlade tb = new TurbineBlade(1500, true, 12, 8, "Ti");
                blades.Add(tb);
                blades.Add(new TurbineBlade(1000, false, 18, 12, "High temp alloy"));
                blades.Add(new TurbineBlade(1350, true, 12, 8, "Ceramic plated alloy"));
                blades.Add(new TurbineBlade(1275, false, 12, 8, "W (tungsten) alloy"));
            }



            spools[0] = new Spool(blades.Where(x => x.MaterialType == "High temp alloy").ToList(), spools[0].Type);
            spools[1] = new Spool(blades.Where(x => x.MaterialType == "W (tungsten) alloy").ToList(), spools[1].Type);
            spools[2] = new Spool(blades.Where(x => x.MaterialType == "Ceramic plated alloy").ToList(), spools[2].Type);
            spools[3] = new Spool(blades.Where(x => x.MaterialType == "Ti").ToList(), spools[3].Type);


            foreach (var spool in spools)
            {
                foreach (var turbineBlade in spool.Blades)
                {
                    turbineBlade.ParentSpool = spool;
                }
            }


            foreach (var spool in spools)
            {
                spoolRepository.Save(spool);
            }

            foreach (var turbineBlade in blades)
            {
                turbineBladeRepository.Save(turbineBlade);
            }

            for (int i = 200; i < 1000; i += 50)
            {
                gasCompartmentRepository.Save(new GasCompartment(i, (float)(i - (i * 0.5))));
            }

            aircraftRegistryRepository.Save(new AircraftRegistry("ER-AXV", false, new DateTime(2003, 9, 22), "622"));
            aircraftRegistryRepository.Save(new AircraftRegistry("N452TA", false, new DateTime(1997, 11, 28), "741"));
            aircraftRegistryRepository.Save(new AircraftRegistry("ER-AXP", false, new DateTime(2011, 11, 3), "741"));
            aircraftRegistryRepository.Save(new AircraftRegistry("B-6156", false, new DateTime(2006, 8, 3), "2849"));
            aircraftRegistryRepository.Save(new AircraftRegistry("ER-AXL", false, new DateTime(2015, 6, 5), "2849"));
            aircraftRegistryRepository.Save(new AircraftRegistry("D-ASSY", false, new DateTime(1997, 3, 26), "666"));
            aircraftRegistryRepository.Save(new AircraftRegistry("SX-BHT", false, new DateTime(2014, 5, 31), "666"));
            aircraftRegistryRepository.Save(new AircraftRegistry("F-OSUD", false, new DateTime(2007, 12, 4), "19000130"));
            aircraftRegistryRepository.Save(new AircraftRegistry("ER-ECC", false, new DateTime(2013, 3, 29), "19000130"));

            Console.WriteLine("\nselecting all turbineblades not made out of W, but are an alloy or can withstand temperatures in excess of 1400 C");
            //SQLQuery2
            //selecting all turbineblades not made out of W, but are an alloy or can withstand temperatures in excess of 1400 C
            IList<TurbineBladeAndSpoolTypeInfoDto> results2 = turbineBladeRepository.GetTurbineBladeAndSpoolTypeInfoDtos();

            foreach (var turbineBladeAndSpoolTypeInfoDto in results2)
            {
                Console.WriteLine(turbineBladeAndSpoolTypeInfoDto.MaterialType);
            }

            Console.WriteLine("\ngets the number of compartments whose capacity is greater than 300 units of volume and their actual capacity ");
            //SQLQuery3
            //gets the number of compartments whose capacity is greater than 300 units of volume and their actual capacity 
            List<GasCompatrmentsCountAndCapacityDto> results3_1 =
                gasCompartmentRepository.GetCompartmetnsCountWithLowerCapacityThan(300);

            foreach (var gasCompatrmentsCountAndCapacityDto in results3_1)
            {
                Console.WriteLine($"Capacity: {gasCompatrmentsCountAndCapacityDto.Capacity}, Count: {gasCompatrmentsCountAndCapacityDto.Count}");
            }

            Console.WriteLine("\nreturns the number of blades that have cooling channels and the number that don't");
            //SQLQuery3
            //returns the number of blades that have cooling channels and the number that don't
            List<TurbineBladeCountDifferentiateOnCoolingChannelsDto> results3_2 =
                turbineBladeRepository.GetNumberOfBladesWithOrWitjoutCooling();

            foreach (var turbineBladeCountDifferentiateOnCoolingChannelsDto in results3_2)
            {
                Console.WriteLine($"Count: {turbineBladeCountDifferentiateOnCoolingChannelsDto.Count}, HasCoolingChannels: {turbineBladeCountDifferentiateOnCoolingChannelsDto.HasCoolingChannels}");
            }

            Console.WriteLine("\ngets all the aircraft info and the number of times it was registered in the registry");
            //SQLQuery4
            //gets all the aircraft info and the number of times it was registered in the registry
            List<AicraftInfoAndNumberOfTimesRegisteredDto> results4_1 =
                aircraftRegistryRepository.GetAicraftInfoAndNumberOfTimesRegistered();

            foreach (var aicraftInfoAndNumberOfTimesRegisteredDto in results4_1)
            {
                Console.WriteLine($"Serial number: {aicraftInfoAndNumberOfTimesRegisteredDto.SerialNumber}, NumberOfTimesRegistered: {aicraftInfoAndNumberOfTimesRegisteredDto.Count}");
            }

            Console.WriteLine("\ngets all aircraft,that have been reregistered more than a year ago");
            //SQLQuery4
            //gets all aircraft,that have been reregistered more than a year ago
            List<AicraftInfoAndDateOfRegistrationDto> results4_2 =
                aircraftRegistryRepository.GetAicraftInfoAndDateOfPenultimateRegistrationDtos(1);

            foreach (var aicraftInfoAndDateOfRegistrationDto in results4_2)
            {
                Console.WriteLine($"Serial number: {aicraftInfoAndDateOfRegistrationDto.SerialNumber}, penultimate registration date: {aicraftInfoAndDateOfRegistrationDto.RegistryDate.Date}");

            }

            Console.WriteLine("\nreturns gas compartments' IDs whose volume is greater than the average volume");
            //SQLQuery4
            //returns gas compartments' IDs whose volume is greater than the average volume
            List<long> result4_3 = gasCompartmentRepository.GetCompartmentsWithLessThanDoubleTheAverageVolume();

            foreach (var l in result4_3)
            {
                Console.WriteLine($"CompartmentID: {l}");
            }

            Console.WriteLine("\ngets turbine blades IDs whose max temp is either the overall maximum or the overall average");
            //SQLQuery4
            //gets turbine blade IDs whose max temp is either the overall maximum or the overall average
            List<long> results4_4 = turbineBladeRepository.GetTubineBladesWithMaxTempInAVGorMAX();

            foreach (var l in results4_4)
            {
                Console.WriteLine($"Turbine blade ID: {l}");
            }

            Console.WriteLine("\nreturns all aircraft whose latest regsitration is more that 5 years old");
            //SQLQuery4
            //returns all aircraft whose latest regsitration is more that 5 years old
            List<AicraftInfoAndDateOfRegistrationDto> results4_5 =
                aircraftRegistryRepository.GetAicraftInfoAndLastDateOfRegistrationDtos(5);

            foreach (var aicraftInfoAndDateOfRegistrationDto in results4_5)
            {
                Console.WriteLine($"Serial number: {aicraftInfoAndDateOfRegistrationDto.SerialNumber}, Registration date: {aicraftInfoAndDateOfRegistrationDto.RegistryDate.Date}");
            }

            Console.WriteLine("\nGets info about aircraft and whether it was registered");
            //SQLQuery4
            //Gets info about aircraft and whether it was registered
            List<AicraftInfoAndIfRegisteredBoolDto> results4_6 =
                aircraftRegistryRepository.GetAicraftInfoAndIfRegisteredBoolDto();


            foreach (var aicraftInfoAndIfRegisteredBoolDto in results4_6)
            {
                Console.WriteLine($"SerialNumber: {aicraftInfoAndIfRegisteredBoolDto.SerialNumber}, is registered: {aicraftInfoAndIfRegisteredBoolDto.IsRegistered}");
            }


            //SQLQuery4
            //List<string> results4_7 = aircraftRegistryRepository.GetAircraftRegisteredInTwoSpecificYears(2003, 1997);

            //foreach (var VARIABLE in results4_7)
            //{
            //    Console.WriteLine($"Serial number: {VARIABLE}");
            //}

            log.Dispose();
        }

        [STAThread]
        private static void StartNewStaThread()
        {
            Application.Run(LogForm.GetLogForm());
        }
    }
}