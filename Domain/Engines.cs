using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Domain
{
    public abstract class Engine : Entity
    {
        private readonly string _manufacturer;
        private readonly string _model;
        private float _currentPower;
        private readonly string _serialNumber;
        private float _maxPower;
        private readonly float _operatingTime;
        private readonly PoweredAircraft _parentAircraft;
        private float _fuelFlow;
        private OnOff _onOffStatus;

        public virtual string Manufacturer
        {
            get { return _manufacturer; }
        }

        public virtual string Model
        {
            get { return _model; }
        }

        public virtual float CurrentPower
        {
            get { return _currentPower; }
            set { _currentPower = value; }
        }

        public virtual string SerialNumber
        {
            get { return _serialNumber; }
        }

        public virtual float MaxPower
        {
            get { return _maxPower; }
            protected set { _maxPower = value; }
        }

        public virtual float OperatingTime
        {
            get { return _operatingTime; }
        }

        public virtual PoweredAircraft ParentAircraft
        {
            get { return _parentAircraft; }
        }

        public virtual float FuelFlow
        {
            get { return _fuelFlow; }
            set { _fuelFlow = value; }
        }

        public virtual OnOff OnOffStatus
        {
            get { return _onOffStatus; }
            set { _onOffStatus = value; }
        }

        public override string ToString()
        {
            return
                String.Format(
                    ", Manufacturer: {0}, model: {1}, current power setting: {2}, serial number: {3}, maximum power output: {4}, operating time: {5}, parent aircraft: {6}, fuel flow {7}, Status: {8}",
                    Manufacturer, Model, CurrentPower, SerialNumber, MaxPower, OperatingTime, ParentAircraft.Id, FuelFlow,
                    OnOffStatus);
        }

        public virtual void Cooldown()
        {
            Console.WriteLine("Cooling down started");
        }

        public virtual void Start()
        {
            if (OnOffStatus == OnOff.Running)
                throw new InvalidOperationException("The engine is already running.");

            CurrentPower = 5;
            FuelFlow = 0.5f;
            OnOffStatus = OnOff.Running;
        }

        public virtual void Stop()
        {
            if (OnOffStatus == OnOff.Stopped)
                throw new InvalidOperationException("\nThe engine was already stopped or wasn't even started.");
            CurrentPower = 0;
            FuelFlow = 0f;
            OnOffStatus = OnOff.Stopped;
        }

        public virtual void IncreasePower()
        {
            if (CurrentPower < 96)
            {
                CurrentPower += 5;
                FuelFlow += 0.5f;
            }
            else
            {
                CurrentPower = 100;
                FuelFlow = 10f;
            }
        }

        public virtual void DecreasePower()
        {
            if (CurrentPower > 5)
            {
                CurrentPower -= 5;
                FuelFlow -= 0.5f;
            }
            else
            {
                CurrentPower = 0;
                FuelFlow = 0f;
            }
        }

        public virtual void WarmUp()
        {
            Console.WriteLine("Warming up engine core for 1 minute. Monitor temps afterward.");
        }

        public Engine()
        {

        }

        public Engine(string manufacturer, string model, string serialnumber, float maxpower, float operatingtime,
            PoweredAircraft parentaircraft, float fuelflow, OnOff stat)
        {
            _manufacturer = manufacturer;
            _model = model;
            _currentPower = 0;
            _maxPower = maxpower;
            _serialNumber = serialnumber;
            _operatingTime = operatingtime;
            _parentAircraft = parentaircraft;
            _fuelFlow = fuelflow;
            _onOffStatus = stat;
        }

        public class EngineComparer : IEqualityComparer<Engine>
        {
            public bool Equals(Engine x, Engine y)
            {
                return x.SerialNumber == y.SerialNumber;
            }

            public int GetHashCode(Engine obj)
            {
                return obj.GetHashCode();
            }
        }
    }

    public class PistonEngine : Engine
    {
        private readonly int _numberOfPistons;
        private readonly float _volume;
        private int _mixture;

        public virtual int NumberOfPistons
        {
            get { return _numberOfPistons; }
        }

        public virtual float Volume
        {
            get { return _volume; }
        }

        public virtual int Mixture
        {
            get { return _mixture; }
            protected set { _mixture = value; }
        }

        public virtual void IncreaseMixture() => Mixture += 10;
        public virtual void LeanMixture() => Mixture -= 10;

        public override string ToString()
        {
            return String.Format("Type: piston engine, number of pistons: {0}, volume: {1}, mixture: {2}, {3}",
                NumberOfPistons, Volume, Mixture, base.ToString());
        }

        public PistonEngine()
        {
            
        }

        public PistonEngine(int numberofpistons, float volume, string manufacturer,
            string model, string serialnumber, float maxpower, float operatingtime,
            PoweredAircraft parentaircraft, float fuelflow, OnOff stat)
            : base(manufacturer, model, serialnumber, maxpower, operatingtime, parentaircraft, fuelflow, stat)
        {
            _numberOfPistons = numberofpistons;
            _volume = volume;
            _mixture = 0;
        }
    }

    public enum OnOff
    {
        [Description("Starting")]
        Starting = 0,
        [Description("Running")]
        Running = 1,
        [Description("ShuttingDown")]
        ShuttingDown = 2,
        [Description("Stopped")]
        Stopped = 3
    }

    public enum PropellantsEnum
    {
        [Description("Jet_A")]
        Jet_A = 0,
        [Description("Jet_B")]
        Jet_B = 1,
        [Description("EtylAclohol")]
        EthylAlcohol = 2,
        [Description("RP_1")]
        RP_1 = 3,
        [Description("LH2")]
        LH2 = 4,
        [Description("Hydrazine")]
        Hydrazine = 5,
        [Description("MonoMethylHydrazine")]
        MonoMethylHydrazine = 6,
        [Description("UnSymmetricalDimethylHydrazine")]
        UnSymmetricalDimethylHydrazine = 7,
        [Description("Lithium")]
        Lithium = 8,
        [Description("Fluorine")]
        Fluorine = 9
    }

    public class Propellant : Entity
    {
        private int _intValue;
        private string _name;
        private JetEngine _parentEngine;

        public virtual int IntValue
        {
            get { return _intValue; }
            protected set { _intValue = value; }
        }

        public virtual String Name
        {
            get { return _name; }
            protected set { _name = value; }
        }

        public virtual PropellantsEnum PropellantEnum
        {
            get { return (PropellantsEnum)IntValue; }
        }

        public virtual JetEngine ParentEngine
        {
            get { return _parentEngine; }
            set { _parentEngine = value; }
        }

        public Propellant()
        {

        }

        public Propellant(PropellantsEnum pr)
        {
            _parentEngine = null;
            _intValue = (int)pr;
            _name = pr.ToString();
        }

        public Propellant(int value, string name)
        {
            _parentEngine = null;
            _intValue = value;
            _name = name;
        }
    }

    public class Oxidiser : Entity
    {
        private int _intValue;
        private string _name;
        private JetEngine _parentEngine;

        public virtual int IntValue
        {
            get { return _intValue; }
            protected set { _intValue = value; }
        }

        public virtual String Name
        {
            get { return _name; }
            protected set { _name = value; }
        }

        public virtual OxidisersEnum PropellantEnum
        {
            get { return (OxidisersEnum)IntValue; }
        }

        public virtual JetEngine ParentEngine
        {
            get { return _parentEngine; }
            set { _parentEngine = value; }
        }

        public Oxidiser()
        {

        }

        public Oxidiser(OxidisersEnum ox)
        {
            _parentEngine = null;
            _intValue = (int)ox;
            _name = ox.ToString();
        }

        public Oxidiser(int value, string name)
        {
            _parentEngine = null;
            _intValue = value;
            _name = name;
        }
    }

    public enum OxidisersEnum
    {
        [Description("GOX")]
        GOX = 0,
        [Description("LOX")]
        LOX = 1,
        [Description("DinitrogenTetroxide")]
        DinitrogenTetroxide = 2,
        [Description("High_TestPeroxide")]
        High_TestPeroxide = 3
    }

    public class JetEngine : Engine
    {
        private readonly int _egt;
        private readonly int _isp;
        private int _numberOfCycles;
        private List<Propellant> _propellants;
        private List<Oxidiser> _oxidisers;

        public virtual int EGT
        {
            get { return _egt; }
        }

        public virtual int Isp
        {
            get { return _isp; }
        }

        public virtual int NumberOfCycles
        {
            get { return _numberOfCycles; }
            set { _numberOfCycles = value; }
        }

        public virtual IList<Propellant> Propellants
        {
            get { return _propellants; }
            protected set { _propellants = value.ToList(); }
        }

        public virtual IList<Oxidiser> Oxidisers
        {
            get { return _oxidisers; }
            protected set { _oxidisers = value.ToList(); }
        }

        public virtual void DecreaseFuelFlow()
        {
        }

        public virtual void IncreaseFuelFlow()
        {
        }

        public override string ToString()
        {
            StringBuilder final = new StringBuilder();
            final.AppendFormat("Type: Jet engine, EGT: {0}, Isp: {1}, number of cycles: {2},\npropellants: ", EGT, Isp,
                NumberOfCycles);

            //foreach (var propellant in Propellants)
            //{
            //    final.AppendFormat("\n\t{0}", propellant);
            //}

            //final.Append(Oxidisers.Aggregate(final + "\noxidisers list:", (current, value) => current + ("\n\t" + value)));

            final.AppendFormat("\n{0}", base.ToString());
            return final.ToString();
        }

        public JetEngine()
        {

        }

        public JetEngine(int egt, int isp, int numberofcycles, List<Propellant> propellants, List<Oxidiser> oxidisers,
            string manufacturer, string model, string serialnumber,
            float maxpower, float operatingtime, PoweredAircraft parentaircraft, float fuelflow, OnOff stat)
            : base(manufacturer, model, serialnumber, maxpower, operatingtime, parentaircraft, fuelflow, stat)
        {
            _egt = egt;
            _isp = isp;
            _numberOfCycles = numberofcycles;
            _propellants = propellants;
            _oxidisers = oxidisers;
        }

    }

    public class Ramjet : JetEngine
    {
        private readonly bool _hasSupersonicCombustion;

        public virtual bool HasSupersonicCombustion
        {
            get { return _hasSupersonicCombustion; }
        }

        public virtual float CheckPressure()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return base.ToString() + "Type: " + (HasSupersonicCombustion ? "Scramjet" : "Ramjet");
        }

        public Ramjet()
        {
            
        }

        public Ramjet(bool hassupersoniccombustion, int egt, int isp, int numberofcycles, List<Propellant> propellants,
            List<Oxidiser> oxidisers,
            string manufacturer, string model, string serialnumber,
            float maxpower, float operatingtime, PoweredAircraft parentaircraft, float fuelflow, OnOff stat)
            : base(
                egt, isp, numberofcycles, propellants, oxidisers, manufacturer, model, serialnumber, maxpower,
                operatingtime, parentaircraft, fuelflow, stat)
        {
            _hasSupersonicCombustion = hassupersoniccombustion;
        }

    }

    public class RocketEngine : JetEngine
    {
        private readonly bool _isReignitable;
        private readonly string _nozzleBellType;

        public virtual bool IsReignitable
        {
            get { return _isReignitable; }
        }

        public virtual string NozzleBellType
        {
            get { return _nozzleBellType; }
        }

        public override string ToString()
        {
            return base.ToString() + "Nozzle bell type: " + NozzleBellType +
                   (IsReignitable ? ", Engine is reignitable" : ", Engine is not regnitable");
        }

        public RocketEngine()
        {
            
        }

        public RocketEngine(bool isreignitable, string nozzlebelltype, int egt, int isp, int numberofcycles,
            List<Propellant> propellants, List<Oxidiser> oxidisers,
            string manufacturer, string model, string serialnumber,
            float maxpower, float operatingtime, PoweredAircraft parentaircraft, float fuelflow, OnOff stat)
            : base(
                egt, isp, numberofcycles, propellants, oxidisers, manufacturer, model, serialnumber, maxpower,
                operatingtime, parentaircraft, fuelflow, stat)
        {
            _isReignitable = isreignitable;
            _nozzleBellType = nozzlebelltype;
        }
    }

    public class SolidFuelRocketEngine : RocketEngine
    {
        //public new virtual float MaxPower
        //{
        //    get { return MaxPower; }
        //    //protected set { }
        //}

        public override float CurrentPower
        {
            get { return MaxPower; }
            set { CurrentPower = MaxPower; }
        }

        private float _maxPower;
        private float _currentPower;

        public override float MaxPower
        {
            get
            {
                return _maxPower;
            }
            protected set {}
        }

        public SolidFuelRocketEngine()
        {
            
        }

        public SolidFuelRocketEngine(bool isreignitable, string nozzlebelltype, int egt, int isp, int numberofcycles,
            List<Propellant> propellants, List<Oxidiser> oxidisers, string manufacturer, string model,
            string serialnumber,
            float maxpower, float operatingtime, PoweredAircraft parentaircraft, float fuelflow, OnOff stat)
            : base(isreignitable, nozzlebelltype, egt, isp, numberofcycles, propellants, oxidisers,
                manufacturer, model, serialnumber, maxpower, operatingtime, parentaircraft, fuelflow, stat)
        {
            _maxPower = maxpower;
            _currentPower = 0;
        }
    }

    public class TurbineEngine : JetEngine, ITurbineEngine
    {
        private readonly bool _hasReverse;
        private readonly int _numberOfShafts;
        private Generator _generator;
        private IList<Spool> _spools;

        public virtual bool HasReverse
        {
            get { return _hasReverse; }
        }

        public virtual int NumberOfShafts
        {
            get { return _numberOfShafts; }
        }

        public virtual Generator Generator
        {
            get { return _generator; }
            set { _generator = value; }
        }

        public virtual IList<Spool> Spools
        {
            get { return _spools; }
            protected set { _spools = value; }
        }


        public virtual void StartGenerator() => Generator.GenerateCurrent();

        public virtual void StopGenerator()
        {
        }

        public virtual void Decorate(ITurbineEngineComponent component = null)
        {
            Console.WriteLine("Customising Engine (TurbineEngine.Decorate)");
        }

        public virtual void Decorate()
        {
            Console.WriteLine("TurbineEngine.Decorate");
        }

        public override string ToString()
        {
            return string.Format("{0}, Number of shafts: {1}, {2}", base.ToString(), NumberOfShafts,
                HasReverse ? "engine has a thrust reverser" : "engine has no thrust reverser");
        }

        public TurbineEngine(bool hasreverse, int numberofshafts, Generator gen, List<Spool> spools, int egt, int isp,
            int numberofcycles, List<Propellant> propellants, List<Oxidiser> oxidisers,
            string manufacturer, string model, string serialnumber,
            float maxpower, float operatingtime, PoweredAircraft parentaircraft, float fuelflow, OnOff stat)
            : base(
                egt, isp, numberofcycles, propellants, oxidisers, manufacturer, model, serialnumber, maxpower,
                operatingtime, parentaircraft, fuelflow, stat)
        {
            _hasReverse = hasreverse;
            _numberOfShafts = numberofshafts;
            //Spools = spools;
            _generator = gen;
        }

        protected TurbineEngine()
        {

        }
    }

    public class Turbofan : TurbineEngine
    {
        private readonly float _bypassRatio;
        private readonly bool _isGeared;

        public virtual float BypassRatio
        {
            get { return _bypassRatio; }
        }

        public virtual bool IsGeared
        {
            get { return _isGeared; }
        }

        public override string ToString()
        {
            return string.Format("{0}, bypass ratio: {1}, {2}", base.ToString(), BypassRatio,
                IsGeared ? "has a geared fan" : "has a direct drive fan");
        }

        public Turbofan(float bypassratio, bool isgeared, bool hasreverse, int numberofshafts, Generator gen,
            List<Spool> spools, int egt, int isp, int numberofcycles, List<Propellant> propellants,
            List<Oxidiser> oxidisers,
            string manufacturer, string model, string serialnumber,
            float maxpower, float operatingtime, PoweredAircraft parentaircraft, float fuelflow, OnOff stat)
            : base(
                hasreverse, numberofshafts, gen, spools, egt, isp, numberofcycles, propellants, oxidisers, manufacturer,
                model, serialnumber, maxpower, operatingtime, parentaircraft, fuelflow, stat)
        {
            _bypassRatio = bypassratio;
            _isGeared = isgeared;
        }

        public Turbofan()
        {
        }
    }

    public class Turboshaft : TurbineEngine
    {
        private readonly float _gearingRatio;
        private readonly float _maxTorque;

        public virtual float GearingRatio
        {
            get { return _gearingRatio; }
        }

        public virtual float MaxTorque
        {
            get { return _maxTorque; }
        }

        public virtual void IncreaseGearingRatio()
        {
        }

        public virtual void DecreaseGearingratio()
        {
        }

        public override void IncreasePower()
        {
            //check for torque limits
            base.IncreasePower();
        }

        public override void DecreasePower()
        {
            base.DecreasePower();
        }

        public override string ToString()
        {
            return string.Format("{0}, gearing ratio: {1}, max torque: {2}", base.ToString(), GearingRatio, MaxTorque);
        }

        public Turboshaft()
        {
        }

        public Turboshaft(float gearingratio, float maxtorque, bool hasreverse, int numberofshafts, Generator gen,
            List<Spool> spools, int egt, int isp, int numberofcycles, List<Propellant> propellants,
            List<Oxidiser> oxidisers,
            string manufacturer, string model, string serialnumber,
            float maxpower, float operatingtime, PoweredAircraft parentaircraft, float fuelflow, OnOff stat)
            : base(
                hasreverse, numberofshafts, gen, spools, egt, isp, numberofcycles, propellants, oxidisers, manufacturer,
                model, serialnumber, maxpower, operatingtime, parentaircraft, fuelflow, stat)
        {
            _gearingRatio = gearingratio;
            _maxTorque = maxtorque;
        }
    }

    public class Turbojet : TurbineEngine
    {
        public virtual string Precoolant { get; }

        public virtual void InjectCoolant()
        {
        }

        public virtual void StopCoolant()
        {
        }

        public override string ToString()
        {
            return base.ToString() + ", precoolant: " + Precoolant;
        }

        public Turbojet()
        {
        }

        public Turbojet(bool hasreverse, int numberofshafts, Generator gen, List<Spool> spools, int egt, int isp,
            int numberofcycles, List<Propellant> propellants, List<Oxidiser> oxidisers,
            string manufacturer, string model, string serialnumber,
            float maxpower, float operatingtime, PoweredAircraft parentaircraft, float fuelflow, OnOff stat,
            string precoolant = null)
            : base(
                hasreverse, numberofshafts, gen, spools, egt, isp, numberofcycles, propellants, oxidisers, manufacturer,
                model, serialnumber, maxpower, operatingtime, parentaircraft, fuelflow, stat)
        {
            Precoolant = precoolant ?? "none";
        }
    }
}