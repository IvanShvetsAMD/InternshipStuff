using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain
{
    public class JetEngine : Engine
    {
        private int _egt;
        private int _isp;
        private int _numberOfCycles;
        private IList<Propellant> _propellants;
        private IList<Oxidiser> _oxidisers;

        public virtual int EGT
        {
            get { return _egt; }
            protected set { _egt = value; }
        }

        public virtual int Isp
        {
            get { return _isp; }
            protected set { _isp = value; }
        }

        public virtual int NumberOfCycles
        {
            get { return _numberOfCycles; }
            protected set { _numberOfCycles = value; }
        }

        public virtual IList<Propellant> Propellants
        {
            get { return _propellants; }
            protected set { _propellants = value; }
        }

        public virtual IList<Oxidiser> Oxidisers
        {
            get { return _oxidisers; }
            protected set { _oxidisers = value; }
        }

        public virtual void DecreaseFuelFlow()
        {
        }

        public virtual void IncreaseFuelFlow()
        {
        }

        public override string ToString()
        {
            //string FinalString;
            //FinalString = String.Format(
            //    "Type: Jet engine, {0}, EGT: {1}, Isp: {2}, number of cycles: {3}, \npropellants: ", base.ToString(), EGT, Isp, NumberOfCycles);

            //foreach (var propellant in Propellants)
            //{
            //    FinalString += "\n\t" + propellant;
            //}

            //return Oxidisers.Aggregate(FinalString + "\noxidiser list:", (current, value) => current + ("\n\t" + value)) + "\n";

            StringBuilder final = new StringBuilder();
            final.AppendFormat("Type: Jet engine, EGT: {0}, Isp: {1}, number of cycles: {2},\npropellants: ", EGT, Isp,
                NumberOfCycles);

            foreach (var propellant in Propellants)
            {
                final.AppendFormat("\n\t{0}", propellant.Name);
            }

            final.Append(Oxidisers.Aggregate(final + "\noxidisers list:", (current, value) => current + ("\n\t" + value.Name)));

            final.AppendFormat("\n{0}", base.ToString());
            return final.ToString();
        }
        
        public JetEngine()
        {

        }

        public JetEngine(int egt, int isp, int numberofcycles, List<Propellant> propellants, List<Oxidiser> oxidisers,
            string manufacturer, string model, string serialnumber,
            float maxpower, float operatingtime, Aircraft parentaircraft, float fuelflow, OnOff stat)
            : base(manufacturer, model, serialnumber, maxpower, operatingtime, parentaircraft, fuelflow, stat)
        {
            _egt = egt;
            _isp = isp;
            _numberOfCycles = numberofcycles;
            _propellants = propellants;
            _oxidisers = oxidisers;
        }
    }
}