using System;
using System.Collections.Generic;

namespace Domain
{
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
}