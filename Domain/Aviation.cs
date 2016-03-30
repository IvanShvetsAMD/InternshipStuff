using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain
{
    public abstract class Aircraft : Entity
    {
        private List<IAviationAdministration> aviationAdministrations;
        private bool isOperational;
        private readonly string _manufacturer;
        private readonly string _model;
        private readonly int _maxTakeoffWeight;
        private readonly int _vne;
        private readonly string _serialNumber;

        public virtual string Manufacturer
        {
            get { return _manufacturer; }
        }

        public virtual string Model
        {
            get { return _model; }
        }

        public virtual int MaxTakeoffWeight
        {
            get { return _maxTakeoffWeight; }
        }

        public virtual int Vne
        {
            get { return _vne; }
        }

        public virtual string SerialNumber
        {
            get { return _serialNumber; }
        }

        public virtual bool IsOperational
        {
            get { return isOperational; }
            set
            {
                isOperational = value;
                if (value == false)
                   NotifyOfCrash();
            }
        }


        public virtual void ReleaseParkingBrake()
        {
            Console.WriteLine("Parking brake released.");
        }

        public virtual void SetParkingBrake()
        {
            Console.WriteLine("Parking brake set.");
        }

        public override string ToString()
        {
            return $"Manufacturer: {Manufacturer}, model: {Model}, maximum takeoff weight: {MaxTakeoffWeight}, Vne: {Vne}, Serial number: {SerialNumber}";
        }

        public virtual void Subscribe(IAviationAdministration administration)
        {
            if (!aviationAdministrations.Contains(administration))
                aviationAdministrations.Add(administration);
        }

        public virtual void Unsubscribe(IAviationAdministration administration)
        {
            if (aviationAdministrations.Contains(administration))
                aviationAdministrations.Remove(administration);
        }

        public virtual void NotifyOfCrash()
        {
            foreach (var aviationAdministration in aviationAdministrations)
            {
                aviationAdministration.GetNotifiedAboutCrash(this);
            }
        }

        public Aircraft(string manufacturer, string model, int maxTOweight, int vne, string serialnumber)
        {
            aviationAdministrations = new List<IAviationAdministration>();
            _manufacturer = manufacturer;
            _model = model;
            _maxTakeoffWeight = maxTOweight;
            _vne = vne;
            _serialNumber = serialnumber;
            isOperational = true;
        }

        protected Aircraft()
        {
            
        }
    }

    public class PoweredAircraft : Aircraft, IPowered
    {
        private readonly List<Engine> _engines;// = new List<Engine>();
        private readonly int _fuelCapacity;

        public virtual IList<Engine> Engines
        {
            get
            {
                return _engines?.ToList();
            }
        }

        public virtual int FuelCapacity
        {
            get { return _fuelCapacity; }
        }

        public virtual float GetCurrentPower(int engineNumber) => Engines[engineNumber].CurrentPower;

        public override string ToString()
        {
            string FinalString = base.ToString() + String.Format(" fuel capacity: {0}\n Engines:", FuelCapacity);
            for (int i = 0; i < Engines.Count; i++)
            {
                FinalString += String.Format("\n\tEngine number: {0}, {1}", i, Engines[i]);
            }
            return FinalString;
        }

        public virtual void DecreasePower(Engine engine)
        {
            engine.DecreasePower();
        }

        public virtual void IncreasePower(Engine engine)
        {
            engine.IncreasePower();
        }

        public virtual float GetCurrentPower(Engine engine)
        {
            return engine.CurrentPower;
        }

        public virtual float GetTotalCurrentPower() => Engines.Sum(engine => engine.CurrentPower);
        public virtual void StartEngine(Engine engine)
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

        public virtual void StopEngine(Engine engine)
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
            _engines = engines;
            _fuelCapacity = fuelcapacity;
        }

        protected PoweredAircraft() { }

        public virtual void MaxPower(Engine engine)
        {
            if (Engines.Contains(engine, new Engine.EngineComparer()))
            {
                Engines.Where(v => v.SerialNumber == engine.SerialNumber).Select(v => v).First().CurrentPower = engine.MaxPower;
            }
        }

        public virtual void IdlePower(Engine engine)
        {
            if (Engines.Contains(engine, new Engine.EngineComparer()))
            {
                Engines.Where(v => v.SerialNumber == engine.SerialNumber).Select(v => v).First().CurrentPower = 1;
            }
        }
    }

    public class LighterThanAirAircraft : PoweredAircraft, ILighterThanAir
    {
        private ILiftingGasPumpModule _gasManager = new SafeGasPumpManager();
        private int _ballastMass;
        private readonly string _gasType;
        private readonly float _gasVolume;
        private readonly IList<GasCompartment> _compartments;

        public virtual ILiftingGasPumpModule GasManager
        {
            get { return _gasManager; }
            set { _gasManager = value; }
        }

        public virtual int BallastMass
        {
            get { return _ballastMass; }
            protected set { _ballastMass = value; }
        }

        public virtual string GasType
        {
            get { return _gasType; }
        }

        public virtual float GasVolume
        {
            get { return _gasVolume; }
        }

        public virtual IList<GasCompartment> Compartments
        {
            get { return _compartments.ToList(); }
        }

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

        public virtual void DumpBallast(int mass)
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

        public virtual void ShiftGas(int originCompartment, int destinationCompartment, float volume)
        {
            GasManager.PumpGas(originCompartment, destinationCompartment, compartments: Compartments.ToList(), volume: volume);
        }

        public LighterThanAirAircraft()
        {
            
        }

        public LighterThanAirAircraft(ILiftingGasPumpModule gasManager, int ballastmass, string gastype, List<GasCompartment> compartments, 
            List<Engine> engines, int fuelcapacity, string manufacturer, string model, int maxTOweight, int vne, string serialnumber)
            : base(engines, fuelcapacity, manufacturer, model, maxTOweight, vne, serialnumber)
        {
            _gasManager = gasManager;
            _ballastMass = ballastmass;
            _gasType = gastype;
            _compartments = compartments;
            _gasVolume = Compartments?.Sum(chamber => chamber.CurrentVolume) ?? 0;
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
        private readonly int _numberOfRotors;
        private readonly List<RotorBlade> _rotorBlades;
        private readonly string _rotorType;

        public virtual int NumberOfRotors
        {
            get { return _numberOfRotors; }
        }

        public virtual IList<RotorBlade> RotorBlades
        {
            get { return _rotorBlades; }
        }

        public virtual string RotorType
        {
            get { return _rotorType; }
        }

        protected virtual void EjectRotorBlades() => RotorBlades.Clear();

        public RotorCraft() { }

        public RotorCraft(int numberofrotors, List<RotorBlade> rotorblades, string rotortype, List<Engine> engines,
            int fuelcapacity, string manufacturer, string model, int maxTOweight, int vne, string serialnumber)
            : base(engines, fuelcapacity, manufacturer, model, maxTOweight, vne, serialnumber)
        {
            _numberOfRotors = numberofrotors;
            _rotorBlades = rotorblades;
            _rotorType = rotortype;
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
        private readonly IList<Wing> _wings;
        private readonly int? _cruiseSpeed;
        private readonly int? _stallSpeed;

        public virtual IList<Wing> Wings
        {
            get { return _wings.ToList(); }
        }

        public virtual int? CruiseSpeed
        {
            get { return _cruiseSpeed; }
        }

        public virtual int? StallSpeed
        {
            get { return _stallSpeed; }
        }

        public FixedWingAircraft()
        {
            
        }

        public FixedWingAircraft(List<Wing> wings, int cruisespeed, int stallspeed, List<Engine> engines,
            int fuelcapacity, string manufacturer, string model, int maxTOweight, int vne, string serialnumber)
            : base(engines, fuelcapacity, manufacturer, model, maxTOweight, vne, serialnumber)
        {
            _wings = wings;
            _cruiseSpeed = cruisespeed;
            _stallSpeed = stallspeed;
        }

        public override string ToString()
        {
            StringBuilder final = new StringBuilder(base.ToString());
            final.AppendFormat(", cruise speed: {0}, stall speed: {1}", CruiseSpeed, StallSpeed);
            return final.ToString();
        }
    }
}