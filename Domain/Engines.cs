using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain
{
    public abstract class Engine
    {
        public string Manufacturer { get; }
        public string Model { get; }
        public virtual float CurrentPower { get; protected set; }
        protected string SerialNumber { get; }
        public virtual float MaxPower { get; protected set; }
        protected float OperatingTime { get; private set; }
        protected string ParentAircraftID { get; private set; }
        public float FuelFlow { get; set; }
        public OnOff OnOffStatus { get; set; }

        public override string ToString()
        {
            return
                String.Format(
                    ", Manufacturer: {0}, model: {1}, current power setting: {2}, serial number: {3}, maximum power output: {4}, operating time: {5}, parent aircraft: {6}, fuel flow {7}, Status: {8}",
                    Manufacturer, Model, CurrentPower, SerialNumber, MaxPower, OperatingTime, ParentAircraftID, FuelFlow, OnOffStatus);
        }

        public void Cooldown()
        {
            Console.WriteLine("Cooling down started");
        }

        public void Start()
        {
            if (OnOffStatus == OnOff.Running)
                throw new InvalidOperationException("The engine is already running.");

            CurrentPower = 5;
            FuelFlow = 0.5f;
            OnOffStatus = OnOff.Running;
        }

        public void Stop()
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

        public void WarmUp()
        {
            Console.WriteLine("Warming up engine core for 1 minute. Monitor temps afterward.");
        }

        public Engine()
        {

        }

        public Engine(string manufacturer, string model, string serialnumber, float maxpower, float operatingtime, string parentaircraftID, float fuelflow, OnOff stat)
        {
            Manufacturer = manufacturer;
            Model = model;
            CurrentPower = 0;
            MaxPower = maxpower;
            SerialNumber = serialnumber;
            OperatingTime = operatingtime;
            ParentAircraftID = parentaircraftID;
            FuelFlow = fuelflow;
            OnOffStatus = stat;
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

    public enum OnOff
    {
        Running,
        Stopped
    }

    public class PistonEngine : Engine
    {
        protected uint NumberOfPistons { get; private set; }
        protected float Volume { get; private set; }
        protected int Mixture { get; private set; }

        public void IncreaseMixture() => Mixture += 10;
        public void LeanMixture() => Mixture -= 10;

        public override string ToString()
        {
            return String.Format("Type: piston engine {0}, number of pistons: {1}, volume: {2}, mixture: {3}", base.ToString(), NumberOfPistons, Volume, Mixture);
        }

        public PistonEngine(uint numberofpistons, float volume, string manufacturer,
            string model, string serialnumber, float maxpower, float operatingtime,
            string parentaircraftID, float fuelflow, OnOff stat) : base(manufacturer, model, serialnumber, maxpower, operatingtime, parentaircraftID, fuelflow, stat)
        {
            NumberOfPistons = numberofpistons;
            Volume = volume;
            Mixture = 0;
        }
    }


    public enum Propellants
    {
        Jet_A,
        Jet_B,
        EthylAlcohol,
        RP_1,
        LH2,
        Hydrazine,
        MonoMethylHydrazine,
        UnSymmetricalDimethylHydrazine,
        Lithium,
        Fluorine
    }

    public enum Oxidisers
    {
        GOX,
        LOX,
        DinitrogenTetroxide,
        High_TestPeroxide
    }
    public class JetEngine : Engine
    {
        protected int EGT { get; private set; }
        protected int Isp { get; private set; }
        public int NumberOfCycles { get; set; }
        protected List<Propellants> Propellants { get; private set; }
        protected List<Oxidisers> Oxidisers { get; private set; }

        public void DecreaseFuelFlow() { }
        public void IncreaseFuelFlow() { }

        public override string ToString()
        {
            string FinalString;
            FinalString = String.Format(
                "Type: Jet engine, {0}, EGT: {1}, Isp: {2}, number of cycles: {3}, \npropellants: ", base.ToString(), EGT, Isp, NumberOfCycles);

            foreach (var propellant in Propellants)
            {
                FinalString += "\n\t" + propellant;
            }

            return Oxidisers.Aggregate(FinalString + "\noxidiser list:", (current, value) => current + ("\n\t" + value)) + "\n";
        }

        public JetEngine()
        {

        }
        public JetEngine(int egt, int isp, int numberofcycles, List<Propellants> propellants, List<Oxidisers> oxidisers,
            string manufacturer, string model, string serialnumber,
            float maxpower, float operatingtime, string parentaircraftID, float fuelflow, OnOff stat) : base(manufacturer, model, serialnumber, maxpower, operatingtime, parentaircraftID, fuelflow, stat)
        {
            EGT = egt;
            Isp = isp;
            NumberOfCycles = numberofcycles;
            Propellants = propellants;
            Oxidisers = oxidisers;
        }

    }

    public class Ramjet : JetEngine
    {
        public bool HasSupersonicCombustion { get; private set; }

        public float CheckPressure()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return base.ToString() + "Type: " + (HasSupersonicCombustion ? "Scramjet" : "Ramjet");
        }

        public Ramjet(bool hassupersoniccombustion, int egt, int isp, int numberofcycles, List<Propellants> propellants, List<Oxidisers> oxidisers,
            string manufacturer, string model, string serialnumber,
            float maxpower, float operatingtime, string parentaircraftID, float fuelflow, OnOff stat)
            : base(egt, isp, numberofcycles, propellants, oxidisers, manufacturer, model, serialnumber, maxpower, operatingtime, parentaircraftID, fuelflow, stat)
        {
            HasSupersonicCombustion = hassupersoniccombustion;
        }

    }

    public class RocketEngine : JetEngine
    {
        protected bool IsReignitable { get; private set; }
        protected string NozzleBellType { get; private set; }

        public override string ToString()
        {
            return base.ToString() + "Nozzle bell type: " + NozzleBellType +
                   (IsReignitable ? ", Engine is reignitable" : ", Engine is not regnitable");
        }

        public RocketEngine(bool isreignitable, string nozzlebelltype, int egt, int isp, int numberofcycles, List<Propellants> propellants, List<Oxidisers> oxidisers,
            string manufacturer, string model, string serialnumber,
            float maxpower, float operatingtime, string parentaircraftID, float fuelflow, OnOff stat)
            : base(egt, isp, numberofcycles, propellants, oxidisers, manufacturer, model, serialnumber, maxpower, operatingtime, parentaircraftID, fuelflow, stat)
        {
            IsReignitable = isreignitable;
            NozzleBellType = nozzlebelltype;
        }
    }

    public class SolidFuelRocketEngine : RocketEngine
    {
        public sealed override float MaxPower { get { return MaxPower; } protected set { } }
        public sealed override float CurrentPower { get { return MaxPower; } protected set { CurrentPower = MaxPower; } }

        public SolidFuelRocketEngine(bool isreignitable, string nozzlebelltype, int egt, int isp, int numberofcycles,
            List<Propellants> propellants, List<Oxidisers> oxidisers, string manufacturer, string model, string serialnumber,
            float maxpower, float operatingtime, string parentaircraftID, float fuelflow, OnOff stat)
            : base(isreignitable, nozzlebelltype, egt, isp, numberofcycles, propellants, oxidisers,
                  manufacturer, model, serialnumber, maxpower, operatingtime, parentaircraftID, fuelflow, stat)
        {
        }
    }

    public class TurbineEngine : JetEngine
    {
        public bool HasReverse { get; private set; }
        public uint NumberOfShafts { get; private set; }
        private Generator generator { get; set; }
        protected List<Spool> Spools { get; private set; }

        public Dictionary<Generator, double> Gens = new Dictionary<Generator, double>(new GeneratorComparer());

        public void StartGenerator() => generator.GenerateCurrent();

        public void StopGenerator() { }

        public override string ToString()
        {
            return string.Format("{0}, Number of shafts: {1}, {2}", base.ToString(), NumberOfShafts, HasReverse ? "engine has a thrust reverser" : "engine has no thrust reverser");
        }

        public TurbineEngine(bool hasreverse, uint numberofshafts, Dictionary<Generator, double> gens, List<Spool> spools, int egt, int isp, int numberofcycles, List<Propellants> propellants, List<Oxidisers> oxidisers,
            string manufacturer, string model, string serialnumber,
            float maxpower, float operatingtime, string parentaircraftID, float fuelflow, OnOff stat)
            : base(egt, isp, numberofcycles, propellants, oxidisers, manufacturer, model, serialnumber, maxpower, operatingtime, parentaircraftID, fuelflow, stat)
        {
            HasReverse = hasreverse;
            NumberOfShafts = numberofshafts;
            Spools = spools;
            Gens = gens;
        }

        protected TurbineEngine()
        {

        }
    }

    public class Turbofan : TurbineEngine
    {
        public float BypassRatio { get; private set; }
        public bool IsGeared { get; private set; }

        public override string ToString()
        {
            return string.Format("{0}, bypass ratio: {1}, {2}", base.ToString(), BypassRatio, IsGeared ? "has a geared fan" : "has a direct drive fan");
        }

        public Turbofan(float bypassratio, bool isgeared, bool hasreverse, uint numberofshafts, Dictionary<Generator, double> gens, List<Spool> spools, int egt, int isp, int numberofcycles, List<Propellants> propellants,
            List<Oxidisers> oxidisers,
            string manufacturer, string model, string serialnumber,
            float maxpower, float operatingtime, string parentaircraftID, float fuelflow, OnOff stat)
            : base(hasreverse, numberofshafts, gens, spools, egt, isp, numberofcycles, propellants, oxidisers, manufacturer, model, serialnumber, maxpower, operatingtime, parentaircraftID, fuelflow, stat)
        {
            BypassRatio = bypassratio;
            IsGeared = isgeared;
        }

        public Turbofan()
        {
        }
    }

    public sealed class Turboshaft : TurbineEngine
    {
        public float GearingRatio { get; private set; }
        public float MaxTorque { get; private set; }

        public void IncreaseGearingRatio() { }
        public void DecreaseGearingratio() { }

        public sealed override void IncreasePower()
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

        public Turboshaft() { }

        public Turboshaft(float gearingratio, float maxtorque, bool hasreverse, uint numberofshafts, Dictionary<Generator, double> gens, List<Spool> spools, int egt, int isp, int numberofcycles, List<Propellants> propellants,
            List<Oxidisers> oxidisers,
            string manufacturer, string model, string serialnumber,
            float maxpower, float operatingtime, string parentaircraftID, float fuelflow, OnOff stat)
            : base(hasreverse, numberofshafts, gens, spools, egt, isp, numberofcycles, propellants, oxidisers, manufacturer, model, serialnumber, maxpower, operatingtime, parentaircraftID, fuelflow, stat)
        {
            GearingRatio = gearingratio;
            MaxTorque = maxtorque;
        }
    }

    public class Turbojet : TurbineEngine
    {
        public string Precoolant { get; }

        public void InjectCoolant() { }
        public void StopCoolant() { }

        public override string ToString()
        {
            return base.ToString() + ", precoolant: " + Precoolant;
        }

        public Turbojet() { }

        public Turbojet(bool hasreverse, uint numberofshafts, Dictionary<Generator, double> gens, List<Spool> spools, int egt, int isp, int numberofcycles, List<Propellants> propellants, List<Oxidisers> oxidisers,
            string manufacturer, string model, string serialnumber,
            float maxpower, float operatingtime, string parentaircraftID, float fuelflow, OnOff stat, string precoolant = null)
            : base(hasreverse, numberofshafts, gens, spools, egt, isp, numberofcycles, propellants, oxidisers, manufacturer, model, serialnumber, maxpower, operatingtime, parentaircraftID, fuelflow, stat)
        {
            Precoolant = precoolant ?? "none";
        }
    }

    public class Generator
    {
        public float OutputCurrent { get; private set; }
        public float OutputVoltage { get; private set; }

        public void GenerateCurrent() { }

        public Generator() { }

        public Generator(float c, float v)
        {
            OutputCurrent = c;
            OutputVoltage = v;
        }
    }

    public class GeneratorComparer : IEqualityComparer<Generator>
    {
        public bool Equals(Generator x, Generator y)
        {
            return NearlyEqual(x.OutputCurrent, y.OutputCurrent, 0.00001f) && NearlyEqual(x.OutputVoltage, y.OutputVoltage, 0.00001f);
        }

        public int GetHashCode(Generator obj)
        {
            return obj.ToString().GetHashCode();
        }

        public bool NearlyEqual(float a, float b, float epsilon)
        {
            float absA = Math.Abs(a);
            float absB = Math.Abs(b);
            float diff = Math.Abs(a - b);

            if (a == b)
                return true;
            if (a == 0 || b == 0 || diff < float.Epsilon)
                return diff < epsilon;
            return diff / (absA + absB) < epsilon;
        }
    }
}