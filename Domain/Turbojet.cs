using System.Collections.Generic;

namespace Domain
{
    public class Turbojet : TurbineEngine
    {
        public string Precoolant { get; }

        public void InjectCoolant()
        {
        }

        public void StopCoolant()
        {
        }

        public override string ToString()
        {
            return base.ToString() + ", precoolant: " + Precoolant;
        }

        public Turbojet()
        {
        }

        public Turbojet(bool hasreverse, uint numberofshafts, Generator gen, List<Spool> spools, int egt, int isp,
            int numberofcycles, List<Propellants> propellants, List<Oxidisers> oxidisers,
            string manufacturer, string model, string serialnumber,
            float maxpower, float operatingtime, string parentaircraftID, float fuelflow, OnOff stat,
            string precoolant = null)
            : base(
                hasreverse, numberofshafts, gen, spools, egt, isp, numberofcycles, propellants, oxidisers, manufacturer,
                model, serialnumber, maxpower, operatingtime, parentaircraftID, fuelflow, stat)
        {
            Precoolant = precoolant ?? "none";
        }
    }
}