using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain
{
    public class JetEngine : Engine
    {
        private readonly int _egt;
        private readonly int _isp;
        private int _numberOfCycles;
        private List<Propellant> _propellants;
        private List<Oxidiser> _oxidisers;

        public virtual int EGT
        {
            get { return _egt; }
        }

        public virtual int Isp
        {
            get { return _isp; }
        }

        public virtual int NumberOfCycles
        {
            get { return _numberOfCycles; }
            set { _numberOfCycles = value; }
        }

        public virtual IList<Propellant> Propellants
        {
            get { return _propellants; }
            protected set { _propellants = value.ToList(); }
        }

        public virtual IList<Oxidiser> Oxidisers
        {
            get { return _oxidisers; }
            protected set { _oxidisers = value.ToList(); }
        }

        public virtual void DecreaseFuelFlow()
        {
        }

        public virtual void IncreaseFuelFlow()
        {
        }

        public override string ToString()
        {
            StringBuilder final = new StringBuilder();
            final.AppendFormat("Type: Jet engine, EGT: {0}, Isp: {1}, number of cycles: {2},\npropellants: ", EGT, Isp,
                NumberOfCycles);

            //foreach (var propellant in Propellants)
            //{
            //    final.AppendFormat("\n\t{0}", propellant);
            //}

            //final.Append(Oxidisers.Aggregate(final + "\noxidisers list:", (current, value) => current + ("\n\t" + value)));

            final.AppendFormat("\n{0}", base.ToString());
            return final.ToString();
        }

        public JetEngine()
        {

        }

        public JetEngine(int egt, int isp, int numberofcycles, List<Propellant> propellants, List<Oxidiser> oxidisers,
            string manufacturer, string model, string serialnumber,
            float maxpower, float operatingtime, PoweredAircraft parentaircraft, float fuelflow, OnOff stat)
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