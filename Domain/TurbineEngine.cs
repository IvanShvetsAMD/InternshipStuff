using System;
using System.Collections.Generic;

namespace Domain
{
    public class TurbineEngine : JetEngine, ITurbineEngine
    {
        private readonly bool _hasReverse;
        private readonly uint _numberOfShafts;
        private Generator _generator;
        private readonly IList<Spool> _spools;

        public virtual bool HasReverse
        {
            get { return _hasReverse; }
        }

        public virtual uint NumberOfShafts
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
        }


        public void StartGenerator() => Generator.GenerateCurrent();

        public void StopGenerator()
        {
        }

        public void Decorate(ITurbineEngineComponent component = null)
        {
            Console.WriteLine("Customising Engine (TurbineEngine.Decorate)");
        }

        public void Decorate()
        {
            Console.WriteLine("TurbineEngine.Decorate");
        }

        public override string ToString()
        {
            return string.Format("{0}, Number of shafts: {1}, {2}", base.ToString(), NumberOfShafts,
                HasReverse ? "engine has a thrust reverser" : "engine has no thrust reverser");
        }

        public TurbineEngine(bool hasreverse, uint numberofshafts, Generator gen, List<Spool> spools, int egt, int isp,
            int numberofcycles, List<Propellants> propellants, List<Oxidisers> oxidisers,
            string manufacturer, string model, string serialnumber,
            float maxpower, float operatingtime, string parentaircraftID, float fuelflow, OnOff stat)
            : base(
                egt, isp, numberofcycles, propellants, oxidisers, manufacturer, model, serialnumber, maxpower,
                operatingtime, parentaircraftID, fuelflow, stat)
        {
            _hasReverse = hasreverse;
            _numberOfShafts = numberofshafts;
            _spools = spools;
            _generator = gen;
        }

        protected TurbineEngine()
        {

        }
    }
}