using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class AviationAdministration : IFAA
    {
        static readonly Lazy<AviationAdministration> LazyInstance = new Lazy<AviationAdministration>(() => new AviationAdministration(), true);
        private List<AircraftRegistration> registeredAircraft = new List<AircraftRegistration>();
        private List<Tuple<string, List<Engine>>> registeredEngines = new List<Tuple<string, List<Engine>>>();

        public static AviationAdministration GetInstance() => LazyInstance.Value;

        public void GetNotifiedAboutEngineChange(PoweredAircraft aircraft)
        {
            registeredEngines.RemoveAll(tuple => tuple.Item1 == aircraft.SerialNumber);
            registeredEngines.Add(new Tuple<string, List<Engine>>(aircraft.SerialNumber, aircraft.Engines));
        }

        public void GetNotifiedAboutCrash(Aircraft aircraft)
        {
            foreach (var registrationEntry in registeredAircraft.Where(entry => entry.Aircraft == aircraft))
            {
                registrationEntry.HasCrashed = false;
            }
            Console.WriteLine("Aircraft crash registered");
        }

        public void RegisterAircraft(PoweredAircraft aircraft, bool isOperational)
        {
            registeredAircraft.Add(new AircraftRegistration(aircraft, isOperational));
            registeredEngines.Add(new Tuple<string, List<Engine>>(aircraft.SerialNumber, aircraft.Engines));
        }

        public void RegisterAircraft(List<AircraftRegistration> registry)
        {
            registeredAircraft.AddRange(registry);
            foreach (var aircraftRegistration in registry)
            {
                registeredEngines.Add(new Tuple<string, List<Engine>>(aircraftRegistration.Aircraft.SerialNumber, aircraftRegistration.Aircraft.Engines));
            }
        }

        public void RegisterEngines(PoweredAircraft aircraft)
        {
            if (registeredAircraft.Count(entry => entry.Aircraft.SerialNumber == aircraft.SerialNumber) == 0)
            {
                RegisterAircraft(aircraft, aircraft.IsOperational);
                return;
            }
            registeredEngines.RemoveAll(tuple => tuple.Item1 == aircraft.SerialNumber);
            registeredEngines.Add(new Tuple<string, List<Engine>>(aircraft.SerialNumber, aircraft.Engines));
        }

        private AviationAdministration()
        {
            
        }

        //public AviationAdministration(List<AircraftRegistration> crafts, List<Tuple<string, List<Engine>>> engines)
        //{
        //    RegisteredAircraft = crafts;
        //    RegisteredEngines = engines;
        //}
    }

    public class NTSB : IAviationAdministration
    {
        static readonly Lazy<NTSB> LazyInstance = new Lazy<NTSB>(() => new NTSB(), true);
        public void GetNotifiedAboutCrash(Aircraft aircraft)
        {
            Console.WriteLine("\nStarting investigation of the crash of {0} {1} (serial number: {2}).\n", aircraft.Manufacturer, aircraft.Model, aircraft.SerialNumber);
        }

        public static IAviationAdministration GetInstance()
        {
            return LazyInstance.Value;
        }
    }

    public class AircraftRegistration
    {
        public PoweredAircraft Aircraft { get; private set; }
        public bool HasCrashed { get; set; }

        public AircraftRegistration(PoweredAircraft aircraft, bool isOperational)
        {
            Aircraft = aircraft;
            HasCrashed = isOperational;
        }
    }
}