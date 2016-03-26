using System;

namespace Domain
{
    public class PistonEngine : Engine
    {
        public uint NumberOfPistons { get; private set; }
        public float Volume { get; private set; }
        public int Mixture { get; private set; }

        public void IncreaseMixture() => Mixture += 10;
        public void LeanMixture() => Mixture -= 10;

        public override string ToString()
        {
            return String.Format("Type: piston engine, number of pistons: {0}, volume: {1}, mixture: {2}, {3}",
                NumberOfPistons, Volume, Mixture, base.ToString());
        }

        public PistonEngine(uint numberofpistons, float volume, string manufacturer,
            string model, string serialnumber, float maxpower, float operatingtime,
            string parentaircraftID, float fuelflow, OnOff stat)
            : base(manufacturer, model, serialnumber, maxpower, operatingtime, parentaircraftID, fuelflow, stat)
        {
            NumberOfPistons = numberofpistons;
            Volume = volume;
            Mixture = 0;
        }
    }
}