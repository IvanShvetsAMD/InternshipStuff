using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code
{
    class TurbofanFactory
    {
        static readonly Lazy<TurbofanFactory> LazyInstance = new Lazy<TurbofanFactory>(() => new TurbofanFactory(), true);
        static TurbofanFactory() { }
        private TurbofanFactory() { }

        public TurbofanFactory GeTurbofanFactory() => LazyInstance.Value;
        public static Turbofan MakeTurbofan(float bypassratio, uint numberofshafts, Dictionary<Generator, double> gens, List<Spool> spools, int egt, int isp,
                                            int numberofcycles, List<Propellants> fueList, List<Oxidisers> oxidisers, string manuf, string model, string serialnumber,
                                            float maxpower, float operatingtime, float fuelflow, OnOff stat, bool isgeared = false, bool hasreverse = true, string parentvehicleID = null)
        {
            //return new Turbofan(3, false, true, 3, new Dictionary<Generator, double>(new GeneratorComparer()),
            //                    new List<Spool>(), 600, 500, 5, new List<Propellants> { Propellants.Jet_A },
            //                    new List<Oxidisers> { Oxidisers.GOX }, "Rolls-Royce", "RB-201", "100000008", 27000, 12, "88", 0, OnOff.Stopped);

            if (numberofshafts < 1)
                throw new ArgumentException("There could be no turbofan with less than one shaft");
            if (spools == null)
                throw new ArgumentNullException(nameof(spools), "A turbine engine has to have some spools");
            if (fueList == null || oxidisers == null)
                throw new ArgumentException("The engine needs fuels and oxidisers, otherwise the notion of an engine has no point.");
            if (string.IsNullOrWhiteSpace(serialnumber))
                throw new ArgumentNullException(nameof(serialnumber), "No serial number provided");


            Console.WriteLine("Creating a new turbofan ({0})", serialnumber);
            return new Turbofan(bypassratio, isgeared, hasreverse, numberofshafts, gens, spools, egt, isp, numberofcycles, fueList, oxidisers,
                                manuf, model, serialnumber, maxpower, operatingtime, parentvehicleID, fuelflow, stat);
        }
    }
}