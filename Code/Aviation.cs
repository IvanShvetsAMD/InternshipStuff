using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Code
{
    abstract class Aircraft
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

        public Aircraft(string manufacturer, string model, int maxTOweight, int vne, string serialnumber)
        {
            Manufacturer = manufacturer;
            Model = model;
            MaxTakeoffWeight = maxTOweight;
            Vne = vne;
            SerialNumber = serialnumber;
        }
    }

    class PoweredAircraft : Aircraft, IPowered
    {
        public List<Engine> Engines { get; private set; }
        public int FuelCapacity { get; private set; }

        public float GetCurrentPower(int EngineNumber) => Engines[EngineNumber].CurrentPower;

        public void DecreasePower(Engine engine)
        {
            if (engine.CurrentPower > 5)
            {
                engine.CurrentPower -= 5;
                engine.FuelFlow -= 0.5f;
            }
            else
            {
                engine.CurrentPower = 0;
                engine.FuelFlow = 0f;
            }
        }

        public void IncreasePower(Engine engine)
        {
            if (engine.CurrentPower < 96)
            {
                engine.CurrentPower += 5;
                engine.FuelFlow += 0.5f;
            }
            else
            {
                engine.CurrentPower = 100;
                engine.FuelFlow = 10f;
            }
        }

        public float GetCurrentPower(Engine engine)
        {
            return engine.CurrentPower;
        }

        public float GetTotalCurrentPower() => Engines.Sum((engine => engine.CurrentPower));
        public void StartEngine(Engine engine)
        {
            engine.WarmUp();
            engine.Start();
        }

        public void StopEngine(Engine engine)
        {
            engine.Stop();
            engine.Cooldown();
        }

        public PoweredAircraft(List<Engine> engines, int fuelcapacity, string manufacturer, string model, int maxTOweight, int vne, string serialnumber) 
            : base (manufacturer, model, maxTOweight, vne, serialnumber)
        {
            Engines = engines;
            FuelCapacity = fuelcapacity;
        }
    }

    class AircraftLighterThanAir : PoweredAircraft, ILighterThanAir
    {
        public uint BallastMass { get; private set; }
        public string GasType { get; private set; }
        public float GasVolume { get; private set; }
        public List<GasCompartment> Compartments { get; private set; }


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

        public void ShiftGasAft(uint OriginCompartment, uint DestinationComnpartment, float Volume)
        {
            //if (Volume > 0)
            //    if (Volume < Compartments[(int)OriginCompartment].Capacity)
            //    {
            //        if (Volume <=
            //            (Compartments[(int)DestinationComnpartment].Capacity -
            //             Compartments[(int)DestinationComnpartment].CurrentVolume))
            //        {
            //            Compartments[(int)OriginCompartment].CurrentVolume -= Volume;
            //            Compartments[(int)DestinationComnpartment].CurrentVolume += Volume;
            //            return;
            //        }
            //        Compartments[(int)OriginCompartment].
            //    }
            
            while (true)
            {
                Compartments[(int) OriginCompartment].CurrentVolume -= 1;
                Compartments[(int) DestinationComnpartment].CurrentVolume += 1;
                Volume -= 1;
                if (Compartments[(int) DestinationComnpartment].CurrentVolume >=
                    Compartments[(int) DestinationComnpartment].Capacity)
                {
                    Compartments[(int) OriginCompartment].CurrentVolume +=
                        Compartments[(int) DestinationComnpartment].CurrentVolume -
                        Compartments[(int) DestinationComnpartment].Capacity;
                    Compartments[(int)DestinationComnpartment].CurrentVolume =
                        Compartments[(int)DestinationComnpartment].Capacity;
                    break;
                }
                if (Volume <= 0)
                {
                    Compartments[(int) OriginCompartment].CurrentVolume += -1*Volume;
                    Compartments[(int) DestinationComnpartment].CurrentVolume -= Volume;
                    break;
                }
            }
        }

        public AircraftLighterThanAir(uint ballastmass, string gastype, float gasvolume, 
            List<GasCompartment> compartments, List<Engine> engines, int fuelcapacity, string manufacturer, string model, int maxTOweight, int vne, string serialnumber) 
            : base(engines, fuelcapacity, manufacturer, model, maxTOweight, vne, serialnumber)
        {
            BallastMass = ballastmass;
            GasType = gastype;
            GasVolume = gasvolume;
            Compartments = compartments;
        }
    }

    class AircraftHeavierThanAir : PoweredAircraft
    {


        public AircraftHeavierThanAir(List<Engine> engines, int fuelcapacity, string manufacturer, string model, int maxTOweight, int vne, string serialnumber) 
            : base(engines, fuelcapacity, manufacturer, model, maxTOweight, vne, serialnumber)
        {
            
        }
        
    }

    class RotorCraft : AircraftHeavierThanAir
    {
        public int NumberOfRotors { get; private set; }
        public List<RotorBlade> RotorBlades { get; private set; } 
        public string RotorType { get; private set; }

        void EjectRotorBlades() => RotorBlades.Clear();

        public RotorCraft(int numberofrotors, List<RotorBlade> rotorblades, string rotortype, List<Engine> engines, 
            int fuelcapacity, string manufacturer, string model, int maxTOweight, int vne, string serialnumber)
            : base(engines, fuelcapacity, manufacturer, model, maxTOweight, vne, serialnumber)
        {
            NumberOfRotors = numberofrotors;
            RotorBlades = rotorblades;
            RotorType = rotortype;
        }
    }

    class FixedWingAircraft : AircraftHeavierThanAir
    {
        private List<Wing> Wings { get;  set; } 
        public int CruiseSpeed { get; }
        public int StallSpeed { get; }

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