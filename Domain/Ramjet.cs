using System;
using System.Collections.Generic;

namespace Domain
{
    public class Ramjet : JetEngine
    {
        private bool _hasSupersonicCombustion;

        public virtual bool HasSupersonicCombustion
        {
            get { return _hasSupersonicCombustion; }
            protected set { _hasSupersonicCombustion = value; }
        }

        public virtual float CheckPressure()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return base.ToString() + "Type: " + (HasSupersonicCombustion ? "Scramjet" : "Ramjet");
        }

        public Ramjet()
        {
            
        }

        public Ramjet(bool hassupersoniccombustion, int egt, int isp, int numberofcycles, List<Propellants> propellants,
            List<Oxidisers> oxidisers,
            string manufacturer, string model, string serialnumber,
            float maxpower, float operatingtime, string parentaircraftID, float fuelflow, OnOff stat)
            : base(
                egt, isp, numberofcycles, propellants, oxidisers, manufacturer, model, serialnumber, maxpower,
                operatingtime, parentaircraftID, fuelflow, stat)
        {
            _hasSupersonicCombustion = hassupersoniccombustion;
        }

    }
}