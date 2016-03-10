using System;
using System.Collections.Generic;
using Interfaces;
using Domain;
using LoggerService;

namespace Factories
{
    public class HeavierThanAirAircraftFactory
    {
        private IAddEngines turbineEngineInstaller;

        public HeavierThanAirAircraftFactory(IAddEngines engineInstaller)
        {
            turbineEngineInstaller = engineInstaller;
        }

        public RotorCraft MakeRotorCraft(string serialnumber, List<RotorBlade> rotorblades, string rotortype = "standart rotor",
                                         int numberofrotors = 1, int fuelcapacity = 0, string manufacturer = "generic aircraft maker", int maxTOweight = 1000)
        {
            if (string.IsNullOrWhiteSpace(serialnumber))
                throw new ArgumentNullException(nameof(serialnumber), "No serial number provided");
            if (rotorblades == null)
                throw new ArgumentNullException(nameof(rotorblades), "No rotor(s) provided");

            return new RotorCraft(numberofrotors, rotorblades, rotortype, new List<Engine>(), fuelcapacity, manufacturer, "generic model", maxTOweight, 0, serialnumber);
        }

        public RotorCraft TryMakeRotorCraft(string serialnumber, List<RotorBlade> rotorblades, string rotortype = "standart rotor",
                                            int numberofrotors = 1, int fuelcapacity = 0, string manufacturer = "generic aircraft maker",
                                            int maxTOweight = 1000)
        {
            RotorCraft rotorCraft = new RotorCraft();

            try
            {
                rotorCraft = MakeRotorCraft(serialnumber, rotorblades, rotortype, numberofrotors, fuelcapacity,
                    manufacturer, maxTOweight);

            }
            catch (ArgumentNullException argumentNullException)
            {
                Console.WriteLine(argumentNullException.Message);
                switch (argumentNullException.ParamName)
                {
                    case nameof(rotorblades):
                        rotorblades = new List<RotorBlade>();
                        rotorCraft = MakeRotorCraft(serialnumber, rotorblades, rotortype, numberofrotors,
                            fuelcapacity, manufacturer, maxTOweight);
                        break;
                    case nameof(serialnumber):
                        serialnumber = "No serial number specified";
                        rotorCraft = MakeRotorCraft(serialnumber, rotorblades, rotortype, numberofrotors,
                            fuelcapacity, manufacturer, maxTOweight: maxTOweight);
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            rotorCraft = AddTurboshaftEngines(rotorCraft);
            Logger.GetLogger().AddToLog(new LogEventArgs(String.Format("new rotorcraft created (SN:{0})", rotorCraft.SerialNumber)));

            rotorCraft.Subscribe(NTSB.GetInstance());
            AviationAdministration.GetInstance().RegisterAircraft(rotorCraft, rotorCraft.IsOperational);

            return rotorCraft;
        }

        private RotorCraft AddTurboshaftEngines(RotorCraft rotorCraft)
        {
            rotorCraft = turbineEngineInstaller.AddTurboshaftEngines(rotorCraft) as RotorCraft;
            return rotorCraft;
        }

        //public FixedWingAircraft MakeFixedWingAircraft(List<Wing> wings, string serialnumber, int cruisespeed = 0, int stallspeed = 0, 
        //                                                int fuelcapacity = 0, string manufacturer = "generic aircraft maker", int maxTOweight = 1000)
        //{
        //    if (string.IsNullOrWhiteSpace(serialnumber))
        //        throw new ArgumentException("No serial number provided");
        //    if (wings == null || wings.Count == 0)
        //        throw new ArgumentNullException(nameof(wings), "no wings list provided or it's empty");

        //    Turbofan tj;
        //    if (TurbineEngineFactory.GeTurbineEngineFactory()
        //            .TryMakeTurbofan(4, 3, new Dictionary<Generator, double>(new GeneratorComparer()),
        //                new List<Spool>(), 600, 500, 5, new List<Propellants> { Propellants.Jet_A },
        //                new List<Oxidisers> { Oxidisers.GOX }, "Standart", "generic model", "100000008", 27000, 88, 0,
        //                OnOff.Stopped, out tj))
        //    {
        //        return new FixedWingAircraft(wings, cruisespeed, stallspeed, new List<Engine> { tj }, fuelcapacity, manufacturer, "generic model", maxTOweight, 0, serialnumber);
        //    }
        //    return null;
        //}
    }
}