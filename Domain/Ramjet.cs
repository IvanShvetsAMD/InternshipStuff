using System;
using System.Collections.Generic;

namespace Domain
{
    public class Ramjet : JetEngine
    {
        private readonly bool _hasSupersonicCombustion;

        public virtual bool HasSupersonicCombustion
        {
            get { return _hasSupersonicCombustion; }
        }

        public virtual float CheckPressure()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return base.ToString() + "Type: " + (HasSupersonicCombustion ? "Scramjet" : "Ramjet");
        }

        protected Ramjet()
        {
            
        }

        public Ramjet(bool hassupersoniccombustion, int egt, int isp, int numberofcycles, List<Propellant> propellants,
            List<Oxidiser> oxidisers,
            string manufacturer, string model, string serialnumber,
            float maxpower, float operatingtime, Aircraft parentaircraft, float fuelflow, OnOff stat)
            : base(
                egt, isp, numberofcycles, propellants, oxidisers, manufacturer, model, serialnumber, maxpower,
                operatingtime, parentaircraft, fuelflow, stat)
        {
            _hasSupersonicCombustion = hassupersoniccombustion;
        }

    }
}