using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain
{
    public abstract class Aircraft
    {
        public string Manufacturer { get; }
        public string Model { get; }
        public int MaxTakeoffWeight { get; private set; }
        public int Vne { get; private set; }
        protected string SerialNumber { get; }


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
            return String.Format("Manufacturer: {0}, model: {1}, maximum takeoff weight: {2}, Vne: {3}, Serial number: {4}", Manufacturer, Model, MaxTakeoffWeight, Vne, SerialNumber);
        }

        public Aircraft(string manufacturer, string model, int maxTOweight, int vne, string serialnumber)
        {
            Manufacturer = manufacturer;
            Model = model;
            MaxTakeoffWeight = maxTOweight;
            Vne = vne;
            SerialNumber = serialnumber;
        }

        protected Aircraft() { }

    }

    public class PoweredAircraft : Aircraft, IPowered
    {
        public List<Engine> Engines { get; private set; }
        public int FuelCapacity { get; private set; }

        public float GetCurrentPower(int EngineNumber) => Engines[EngineNumber].CurrentPower;

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

        public float GetTotalCurrentPower() => Engines.Sum((engine => engine.CurrentPower));
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
        public uint BallastMass { get; private set; }
        public string GasType { get; private set; }
        public float GasVolume { get; private set; }
        public Dictionary<uint, GasCompartment> Compartments { get; }

        public override string ToString()
        {
            string FinalString = base.ToString();
            FinalString += string.Format("\n ballast mass: {0}, gas type: {1}, gas volume {2}\n Gas compartments:", BallastMass, GasType, GasVolume);
            return Compartments.Aggregate(FinalString, (current, gasCompartment) => current + String.Format("\n\tCompartment number : {0}, {1}", gasCompartment.Key, gasCompartment.ToString()));
        }

        public void DumpBallast(uint TankNumber, uint mass)
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

        public void ShiftGas(uint OriginCompartment, uint DestinationCompartment, float Volume)
        {
            if (OriginCompartment == DestinationCompartment)
                throw new Exception("No point in shifting gas - the source and the destination match.");
            if (!Compartments.ContainsKey(OriginCompartment) || !Compartments.ContainsKey(DestinationCompartment))
                throw new GasCompartmentsNotFoundException("One or both the compartments are not present in the airship.", OriginCompartment, DestinationCompartment);
            while (true)
            {
                Compartments[OriginCompartment].CurrentVolume -= 1;
                Compartments[DestinationCompartment].CurrentVolume += 1;
                Volume -= 1;
                if (Compartments[DestinationCompartment].CurrentVolume >=
                    Compartments[DestinationCompartment].Capacity)
                {
                    Compartments[OriginCompartment].CurrentVolume +=
                        Compartments[DestinationCompartment].CurrentVolume -
                        Compartments[DestinationCompartment].Capacity;
                    Compartments[DestinationCompartment].CurrentVolume = Compartments[DestinationCompartment].Capacity;
                    break;
                }
                if (Volume <= 0)
                {
                    Compartments[OriginCompartment].CurrentVolume += -1 * Volume;
                    Compartments[DestinationCompartment].CurrentVolume -= -Volume;
                    break;
                }
            }
        }

        public LighterThanAirAircraft(uint ballastmass, string gastype, float gasvolume,
            Dictionary<uint, GasCompartment> compartments, List<Engine> engines, int fuelcapacity, string manufacturer, string model, int maxTOweight, int vne, string serialnumber)
            : base(engines, fuelcapacity, manufacturer, model, maxTOweight, vne, serialnumber)
        {
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
    }
}