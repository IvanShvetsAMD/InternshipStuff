using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain
{
    public class PoweredAircraft : Aircraft, IPowered
    {
        private readonly IList<Engine> _engines;
        private readonly int _fuelCapacity;

        public virtual IList<Engine> Engines
        {
            get { return _engines; }
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
            throw new NotImplementedException();
        }

        public virtual void IdlePower(Engine engine)
        {
            throw new NotImplementedException();
        }
    }
}