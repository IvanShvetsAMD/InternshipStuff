using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain
{
    public abstract class Aircraft
    {
        private List<IAviationAdministration> aviationAdministrations;
        private bool isOperational;
        public string Manufacturer { get; }
        public string Model { get; }
        public int MaxTakeoffWeight { get; private set; }
        public int Vne { get; private set; }
        public string SerialNumber { get; }

        public bool IsOperational
        {
            get { return isOperational; }
            set
            {
                isOperational = value;
                if (value == false)
                    NotifyOfCrash();
            }
        }


        public void ReleaseParkingBrake()
        {
            Console.WriteLine("Parking brake released.");
        }

        public void SetParkingBrake()
        {
            Console.WriteLine("Parking brake set.");
        }

        public override string ToString()
        {
            return $"Manufacturer: {Manufacturer}, model: {Model}, maximum takeoff weight: {MaxTakeoffWeight}, Vne: {Vne}, Serial number: {SerialNumber}";
        }

        public void Subscribe(IAviationAdministration administration)
        {
            if(!aviationAdministrations.Contains(administration))
                aviationAdministrations.Add(administration);
        }

        public void Unsubscribe(IAviationAdministration administration)
        {
            if (aviationAdministrations.Contains(administration))
                aviationAdministrations.Remove(administration);
        }

        public void NotifyOfCrash()
        {
            foreach (var aviationAdministration in aviationAdministrations)
            {
                aviationAdministration.GetNotifiedAboutCrash(this);
            }
        }

        public Aircraft(string manufacturer, string model, int maxTOweight, int vne, string serialnumber)
        {
            aviationAdministrations = new List<IAviationAdministration>();
            Manufacturer = manufacturer;
            Model = model;
            MaxTakeoffWeight = maxTOweight;
            Vne = vne;
            SerialNumber = serialnumber;
            IsOperational = true;
        }

        protected Aircraft() { }

    }

    public class PoweredAircraft : Aircraft, IPowered
    {
        public List<Engine> Engines { get; private set; }
        public int FuelCapacity { get; private set; }

        public float GetCurrentPower(int engineNumber) => Engines[engineNumber].CurrentPower;

        public override string ToString()
        {
            string FinalString = base.ToString() + String.Format(" fuel capacity: {0}\n Engines:", FuelCapacity);
            for (int i = 0; i < Engines.Count; i++)
            {
                FinalString += String.Format("\n\tEngine number: {0}, {1}", i, Engines[i]);
            }
            return FinalString;
        }

        public void DecreasePower(Engine engine)
        {
            engine.DecreasePower();
        }

        public void IncreasePower(Engine engine)
        {
            engine.IncreasePower();
        }

        public float GetCurrentPower(Engine engine)
        {
            return engine.CurrentPower;
        }

        public float GetTotalCurrentPower() => Engines.Sum(engine => engine.CurrentPower);
        public void StartEngine(Engine engine)
        {
            try
            {
                engine.WarmUp();
                engine.Start();
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message + "engine number: " + Engines.IndexOf(engine));
            }
        }

        public void StopEngine(Engine engine)
        {
            try
            {
                engine.Stop();
                engine.Cooldown();
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message + "engine number: " + Engines.IndexOf(engine));
                //throw new Exception("\nEngine if already off", e);
                throw;
            }
        }

        public PoweredAircraft(List<Engine> engines, int fuelcapacity, string manufacturer, string model, int maxTOweight, int vne, string serialnumber)
            : base(manufacturer, model, maxTOweight, vne, serialnumber)
        {
            Engines = engines;
            FuelCapacity = fuelcapacity;
        }

        protected PoweredAircraft() { }

        public void MaxPower(Engine engine)
        {
            throw new NotImplementedException();
        }

        public void IdlePower(Engine engine)
        {
            throw new NotImplementedException();
        }
    }

    public class LighterThanAirAircraft : PoweredAircraft, ILighterThanAir
    {
        public ILiftingGasPumpModule GasManager { get; set; } = new SafeGasPumpManager();
        public uint BallastMass { get; private set; }
        public string GasType { get; private set; }
        public float GasVolume { get; private set; }
        public List<GasCompartment> Compartments { get; }

        public override string ToString()
        {
            StringBuilder final = new StringBuilder(base.ToString());
            final.AppendFormat("\n ballast mass: {0}, gas type: {1}, gas volume {2}\n Gas compartments:", BallastMass, GasType, GasVolume);

            foreach (var gasCompartment in Compartments)
            {
                final.AppendFormat("\n\tCompartment number: {0}, {1} ", Compartments.IndexOf(gasCompartment),gasCompartment);
            }
            return final.ToString();
        }

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
        }

        public void ShiftGas(int originCompartment, int destinationCompartment, float volume)
        {
            GasManager.PumpGas(originCompartment, destinationCompartment, compartments: Compartments, volume: volume);
        }

        public LighterThanAirAircraft(ILiftingGasPumpModule gasManager, uint ballastmass, string gastype, float gasvolume,
            List<GasCompartment> compartments, List<Engine> engines, int fuelcapacity, string manufacturer, string model, int maxTOweight, int vne, string serialnumber)
            : base(engines, fuelcapacity, manufacturer, model, maxTOweight, vne, serialnumber)
        {
            GasManager = gasManager;
            BallastMass = ballastmass;
            GasType = gastype;
            GasVolume = gasvolume;
            Compartments = compartments;
        }
    }

    public class HeavierThanAirAircraft : PoweredAircraft
    {


        public HeavierThanAirAircraft(List<Engine> engines, int fuelcapacity, string manufacturer, string model, int maxTOweight, int vne, string serialnumber)
            : base(engines, fuelcapacity, manufacturer, model, maxTOweight, vne, serialnumber)
        {

        }

        protected HeavierThanAirAircraft() { }
    }

    public class RotorCraft : HeavierThanAirAircraft
    {
        public int NumberOfRotors { get; private set; }
        public List<RotorBlade> RotorBlades { get; private set; }
        public string RotorType { get; private set; }

        void EjectRotorBlades() => RotorBlades.Clear();

        public RotorCraft() { }

        public RotorCraft(int numberofrotors, List<RotorBlade> rotorblades, string rotortype, List<Engine> engines,
            int fuelcapacity, string manufacturer, string model, int maxTOweight, int vne, string serialnumber)
            : base(engines, fuelcapacity, manufacturer, model, maxTOweight, vne, serialnumber)
        {
            NumberOfRotors = numberofrotors;
            RotorBlades = rotorblades;
            RotorType = rotortype;
        }

        public override string ToString()
        {
            StringBuilder final = new StringBuilder(base.ToString());
            final.AppendFormat(", number of rotors: {0}, type of rotor: {1}", NumberOfRotors, RotorType);
            return final.ToString();
        }
    }

    public class FixedWingAircraft : HeavierThanAirAircraft
    {
        public List<Wing> Wings { get; private set; }
        public int? CruiseSpeed { get; }
        public int? StallSpeed { get; }

        public FixedWingAircraft(List<Wing> wings, int cruisespeed, int stallspeed, List<Engine> engines,
            int fuelcapacity, string manufacturer, string model, int maxTOweight, int vne, string serialnumber)
            : base(engines, fuelcapacity, manufacturer, model, maxTOweight, vne, serialnumber)
        {
            Wings = wings;
            CruiseSpeed = cruisespeed;
            StallSpeed = stallspeed;
        }

        public override string ToString()
        {
            StringBuilder final = new StringBuilder(base.ToString());
            final.AppendFormat(", cruise speed: {0}, stall speed: {1}", CruiseSpeed, StallSpeed);
            return final.ToString();
        }
    }
}