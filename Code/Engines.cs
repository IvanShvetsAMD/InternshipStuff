using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;

namespace Code
{
    abstract class Engine
    {
        public string Manufacturer { get; }
        public string Model { get; }
        public float CurrentPower { get; set; }
        protected string SerialNumber { get; }
        public float MaxPower { get; private set; }
        protected float OperatingTime { get; private set; }
        protected string ParentAircraftID { get; private set; }
        public float FuelFlow { get; set; }

        public override string ToString()
        {
            return
                String.Format(
                    "Manufacturer: {0}, model: {1}, current power setting: {2}, serial number: {3}, maximun power output: {4}, operating time: {5}, parent aircraft: {6}, fuel flow {7}",
                    Manufacturer, Model, CurrentPower, SerialNumber, MaxPower, OperatingTime, ParentAircraftID, FuelFlow);
        }

        public void Cooldown()
        {
            Console.WriteLine("Cooling down started");
        }

        public void Start()
        {
            CurrentPower = 5;
            FuelFlow = 0.5f;
        }

        public void Stop()
        {
            CurrentPower = 0;
            FuelFlow = 0f;
        }

        public void WarmUp()
        {
            Console.WriteLine(  "Warming up engine core for 1 minute. Monitor temps afterward.");
        }

        public Engine(string manufacturer, string model, string serialnumber, float maxpower, float operatingtime, string parentaircraftID, float fuelflow)
        {
            Manufacturer = manufacturer;
            Model = model;
            CurrentPower = 0;
            MaxPower = maxpower;
            SerialNumber = serialnumber;
            OperatingTime = operatingtime;
            ParentAircraftID = parentaircraftID;
            FuelFlow = fuelflow;
        }
    }

    class PistonEngine : Engine
    {
        protected uint NumberOfPistons { get; private set; }
        protected float Volume { get; private set; }
        protected int Mixture { get; private set; }

        public void IncreaseMixture() => Mixture += 10;
        public void LeanMixture() => Mixture -= 10;

        public override string ToString()
        {
            return "Type: piston engine" + base.ToString() +
                   String.Format("number of pistons: {0}, volume: {1}, mixture: {2}", NumberOfPistons, Volume, Mixture);
        }

        public PistonEngine(uint numberofpistons, float volume, string manufacturer,
            string model, string serialnumber, float maxpower, float operatingtime,
            string parentaircraftID, float fuelflow) : base(manufacturer, model, serialnumber, maxpower, operatingtime, parentaircraftID, fuelflow)
        {
            NumberOfPistons = numberofpistons;
            Volume = volume;
            Mixture = 0;
        }
    }

    class JetEngine : Engine
    {
        protected int EGT { get; private set; }
        protected int Isp { get; private set; }
        public int NumberOfCycles { get; set; }
        protected List<string> Propellants { get; private set; }

        public void DecreaseFuelFlow() { }
        public void IncreaseFuelFlow() { }

        public override string ToString()
        {
            string FinalString;
            FinalString = "Type: Jet engine" + base.ToString() + String.Format("EGT: {0}, Isp: {1}, number of cycles{2}, propellants: ");
            foreach (var propellant in Propellants)
            {
                FinalString += " " + propellant;
            }
            return FinalString;
        }

        public JetEngine(int egt, int isp, int numberofcycles, List<string> propellants,
            string manufacturer, string model, string serialnumber,
            float maxpower, float operatingtime, string parentaircraftID, float fuelflow) : base(manufacturer, model, serialnumber, maxpower, operatingtime, parentaircraftID, fuelflow)
        {
            EGT = egt;
            Isp = isp;
            NumberOfCycles = numberofcycles;
            Propellants = propellants;
        }

    }

    class Ramjet : JetEngine
    {
        public bool HasSupersonicCombustion { get; private set; }

        public float CheckPressure()
        {
            throw new NotImplementedException();
        }

        public Ramjet(bool hassupersoniccombustion, int egt, int isp, int numberofcycles, List<string> propellants,
            string manufacturer, string model, string serialnumber,
            float maxpower, float operatingtime, string parentaircraftID, float fuelflow) 
            : base(egt, isp, numberofcycles, propellants, manufacturer, model, serialnumber, maxpower, operatingtime, parentaircraftID, fuelflow)
        {
            HasSupersonicCombustion = hassupersoniccombustion;
        }

    }

    class RocketEngine : JetEngine
    {
        protected bool IsReignitable { get; private set; }
        protected string NozzleBellType { get; private set; }

        public RocketEngine(bool isreignitable, string nozzlebelltype, int egt, int isp, int numberofcycles, List<string> propellants,
            string manufacturer, string model, string serialnumber,
            float maxpower, float operatingtime, string parentaircraftID, float fuelflow) 
            : base(egt, isp, numberofcycles, propellants, manufacturer, model, serialnumber, maxpower, operatingtime, parentaircraftID, fuelflow)
        {

        }
    }

    class TurbineEngine : JetEngine
    {
        public bool HasReverse { get; private set; }
        public uint NumberOfShafts { get; private set; }
        private Generator generator { get; set; }
        protected List<Spool> Spools { get; private set; }

        public void StartGenerator() => generator.GenerateCurrent();

        public void StopGenerator() { }

        public TurbineEngine(bool hasreverse, uint numberofshafts, List<Spool> spools, int egt, int isp, int numberofcycles, List<string> propellants,
            string manufacturer, string model, string serialnumber,
            float maxpower, float operatingtime, string parentaircraftID, float fuelflow)
            : base(egt, isp, numberofcycles, propellants, manufacturer, model, serialnumber, maxpower, operatingtime, parentaircraftID, fuelflow)
        {
            HasReverse = hasreverse;
            NumberOfShafts = numberofshafts;
            Spools = spools;
        }
    }

    class Turbofan : TurbineEngine
    {
        public float BypassRatio { get; private set; }
        public bool IsGeared { get; private set; }

        public Turbofan(float bypassratio, bool isgeared, bool hasreverse, uint numberofshafts, List<Spool> spools, int egt, int isp, int numberofcycles, List<string> propellants,
            string manufacturer, string model, string serialnumber,
            float maxpower, float operatingtime, string parentaircraftID, float fuelflow)
            : base(hasreverse, numberofshafts, spools, egt, isp, numberofcycles, propellants, manufacturer, model, serialnumber, maxpower, operatingtime, parentaircraftID, fuelflow)
        {
            BypassRatio = bypassratio;
            IsGeared = isgeared;
        }
    }

    class Turboshaft : TurbineEngine
    {
        public float GearingRatio { get; private set; }
        public float MaxTorque { get; private set; }

        public void IncreaseGearingRatio() { }
        public void DecreaseGearingratio() { }

        public Turboshaft(float gearingratio, float maxtorque, bool hasreverse, uint numberofshafts, List<Spool> spools, int egt, int isp, int numberofcycles, List<string> propellants,
            string manufacturer, string model, string serialnumber,
            float maxpower, float operatingtime, string parentaircraftID, float fuelflow)
            : base(hasreverse, numberofshafts, spools, egt, isp, numberofcycles, propellants, manufacturer, model, serialnumber, maxpower, operatingtime, parentaircraftID, fuelflow)
        {
            GearingRatio = gearingratio;
            MaxTorque = maxtorque;
        }
    }

    class Turbojet : TurbineEngine
    {
        public string Precoolant { get; }

        public void InjectCoolant() { }
        public void StopCoolant() { }

        public Turbojet(String precoolant, bool hasreverse, uint numberofshafts, List<Spool> spools, int egt, int isp, int numberofcycles, List<string> propellants,
            string manufacturer, string model, string serialnumber,
            float maxpower, float operatingtime, string parentaircraftID, float fuelflow)
            : base(hasreverse, numberofshafts, spools, egt, isp, numberofcycles, propellants, manufacturer, model, serialnumber, maxpower, operatingtime, parentaircraftID, fuelflow)
        {
            Precoolant = precoolant;
        }
    }

    class Generator
    {
        public float OutputCurrent { get; private set; }
        public float OutputVoltage { get; private set; }

        public void GenerateCurrent() { }

        public Generator() { }
    }
}