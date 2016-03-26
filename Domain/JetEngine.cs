using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain
{
    public class JetEngine : Engine
    {
        public int EGT { get; protected set; }
        public int Isp { get; protected set; }
        public int NumberOfCycles { get; protected set; }
        public List<Propellants> Propellants { get; protected set; }
        public List<Oxidisers> Oxidisers { get; protected set; }

        public void DecreaseFuelFlow()
        {
        }

        public void IncreaseFuelFlow()
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
                final.AppendFormat("\n\t{0}", propellant);
            }

            final.Append(Oxidisers.Aggregate(final + "\noxidisers list:", (current, value) => current + ("\n\t" + value)));

            final.AppendFormat("\n{0}", base.ToString());
            return final.ToString();
        }

        public JetEngine()
        {

        }

        public JetEngine(int egt, int isp, int numberofcycles, List<Propellants> propellants, List<Oxidisers> oxidisers,
            string manufacturer, string model, string serialnumber,
            float maxpower, float operatingtime, string parentaircraftID, float fuelflow, OnOff stat)
            : base(manufacturer, model, serialnumber, maxpower, operatingtime, parentaircraftID, fuelflow, stat)
        {
            EGT = egt;
            Isp = isp;
            NumberOfCycles = numberofcycles;
            Propellants = propellants;
            Oxidisers = oxidisers;
        }

    }
}