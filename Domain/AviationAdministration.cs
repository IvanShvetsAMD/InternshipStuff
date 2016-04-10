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

        //List<Tuple<PoweredAircraft, bool>> Registry = new List<Tuple<PoweredAircraft, bool>>();

        public static AviationAdministration GetInstance() => LazyInstance.Value;

        public void GetNotifiedAboutEngineChange(PoweredAircraft aircraft)
        {
            registeredEngines.RemoveAll(tuple => tuple.Item1 == aircraft.SerialNumber);
            registeredEngines.Add(new Tuple<string, List<Engine>>(aircraft.SerialNumber, aircraft.Engines.ToList()));
        }

        public void GetNotifiedAboutCrash(Aircraft aircraft)
        {
            foreach (var registrationEntry in registeredAircraft.Where(entry => entry.Aircraft == aircraft))
            {
                registrationEntry.HasCrashed = false;
            }

            //for (int index = 0; index < Registry.Count; index++)
            //{
            //    if (Registry[index].Item1 == aircraft)
            //    {
            //        Registry[index] = new Tuple<PoweredAircraft, bool>(Registry[index].Item1, true);
            //    }
            //}
            Console.WriteLine("Aircraft crash registered");
        }

        public void RegisterAircraft(PoweredAircraft aircraft, bool isOperational)
        {
            registeredAircraft.Add(new AircraftRegistration(aircraft, isOperational));
            registeredEngines.Add(new Tuple<string, List<Engine>>(aircraft.SerialNumber, aircraft.Engines.ToList()));
        }

        public void RegisterAircraftList(List<AircraftRegistration> registry)
        {
            registeredAircraft.AddRange(registry);
            foreach (var aircraftRegistration in registry)
            {
                registeredEngines.Add(new Tuple<string, List<Engine>>(aircraftRegistration.Aircraft.SerialNumber, aircraftRegistration.Aircraft.Engines.ToList()));
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
            registeredEngines.Add(new Tuple<string, List<Engine>>(aircraft.SerialNumber, aircraft.Engines.ToList()));
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

    public class AircraftRegistration
    {
        public bool HasCrashed { get; set; }
        public PoweredAircraft Aircraft { get; set; }

        public AircraftRegistration(PoweredAircraft Aircraft, bool HasCrashed)
        {
            this.HasCrashed = HasCrashed;
            this.Aircraft = Aircraft;
        }
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

    public class AircraftRegistry : Entity
    {
        private bool _hasCrashed;
        private readonly string _aircraftRegistrationEntry;
        private readonly DateTime _registrationDate;
        private readonly string _serialNumber;

        public virtual String AircraftRegistrationEntry
        {
            get { return _aircraftRegistrationEntry.ToUpperInvariant(); }
        }

        public virtual bool HasCrashed
        {
            get { return _hasCrashed; }
            set { _hasCrashed = value; }
        }

        public virtual DateTime RegistrationDate
        {
            get { return _registrationDate; }
        }

        public virtual string SerialNumber
        {
            get { return _serialNumber.ToUpperInvariant(); }
        }

        public AircraftRegistry()
        {
            
        }

        public AircraftRegistry(string aircraftRegistration, bool hasCrashed, DateTime registrationdate, string serialNumber)
        {
            _aircraftRegistrationEntry = aircraftRegistration.ToUpperInvariant();
            _hasCrashed = hasCrashed;
            _serialNumber = serialNumber;
            _registrationDate = registrationdate.Date;
        }
    }
}