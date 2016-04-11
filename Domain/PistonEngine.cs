using System;

namespace Domain
{
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
}