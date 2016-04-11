using System.Collections.Generic;

namespace Domain
{
    public class SolidFuelRocketEngine : RocketEngine
    {
        //public new virtual float MaxPower
        //{
        //    get { return MaxPower; }
        //    //protected set { }
        //}

        public override float CurrentPower
        {
            get { return MaxPower; }
            set { CurrentPower = MaxPower; }
        }

        private float _maxPower;
        private float _currentPower;

        public override float MaxPower
        {
            get
            {
                return _maxPower;
            }
            protected set {}
        }

        public SolidFuelRocketEngine()
        {
            
        }

        public SolidFuelRocketEngine(bool isreignitable, string nozzlebelltype, int egt, int isp, int numberofcycles,
            List<Propellant> propellants, List<Oxidiser> oxidisers, string manufacturer, string model,
            string serialnumber,
            float maxpower, float operatingtime, PoweredAircraft parentaircraft, float fuelflow, OnOff stat)
            : base(isreignitable, nozzlebelltype, egt, isp, numberofcycles, propellants, oxidisers,
                manufacturer, model, serialnumber, maxpower, operatingtime, parentaircraft, fuelflow, stat)
        {
            _maxPower = maxpower;
            _currentPower = 0;
        }
    }
}