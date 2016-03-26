using System.Collections.Generic;

namespace Domain
{
    public class SolidFuelRocketEngine : RocketEngine
    {
        public sealed override float MaxPower
        {
            get { return MaxPower; }
            protected set { }
        }

        public sealed override float CurrentPower
        {
            get { return MaxPower; }
            protected set { CurrentPower = MaxPower; }
        }

        public SolidFuelRocketEngine(bool isreignitable, string nozzlebelltype, int egt, int isp, int numberofcycles,
            List<Propellants> propellants, List<Oxidisers> oxidisers, string manufacturer, string model,
            string serialnumber,
            float maxpower, float operatingtime, string parentaircraftID, float fuelflow, OnOff stat)
            : base(isreignitable, nozzlebelltype, egt, isp, numberofcycles, propellants, oxidisers,
                manufacturer, model, serialnumber, maxpower, operatingtime, parentaircraftID, fuelflow, stat)
        {
            MaxPower = maxpower;
            CurrentPower = CurrentPower;
        }
    }
}