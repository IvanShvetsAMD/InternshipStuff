using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain
{
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
            if (Engines != null)
            {
                for (int i = 0; i < Engines.Count; i++)
                {
                    FinalString += String.Format("\n\tEngine number: {0}, {1}", i, Engines[i]);
                }
            }
            else
            {
                FinalString += "\nNo engines installed\n";
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
}