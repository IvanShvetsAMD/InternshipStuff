using System.Collections.Generic;

namespace Domain
{
    public class SolidFuelRocketEngine : RocketEngine
    {
        public virtual float MaxPower
        {
            get { return MaxPower; }
            protected set { }
        }

        public virtual float CurrentPower
        {
            get { return MaxPower; }
            protected set { CurrentPower = MaxPower; }
        }

        protected SolidFuelRocketEngine()
        {
            
        }

        public SolidFuelRocketEngine(bool isreignitable, string nozzlebelltype, int egt, int isp, int numberofcycles,
            List<Propellant> propellants, List<Oxidiser> oxidisers, string manufacturer, string model,
            string serialnumber,
            float maxpower, float operatingtime, Aircraft parentaircraft, float fuelflow, OnOff stat)
            : base(isreignitable, nozzlebelltype, egt, isp, numberofcycles, propellants, oxidisers,
                manufacturer, model, serialnumber, maxpower, operatingtime, parentaircraft, fuelflow, stat)
        {
            MaxPower = maxpower;
            CurrentPower = CurrentPower;
        }
    }
}