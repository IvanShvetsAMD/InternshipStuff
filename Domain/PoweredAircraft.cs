using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain
{
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
}