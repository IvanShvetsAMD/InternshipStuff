using System.Collections.Generic;

namespace Domain
{
    public class Turbojet : TurbineEngine
    {
        private readonly string _precoolant;

        public virtual string Precoolant
        {
            get { return _precoolant; }
        }

        public virtual void InjectCoolant()
        {
        }

        public virtual void StopCoolant()
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
            int numberofcycles, List<Propellant> propellants, List<Oxidiser> oxidisers,
            string manufacturer, string model, string serialnumber,
            float maxpower, float operatingtime, Aircraft parentaircraft, float fuelflow, OnOff stat,
            string precoolant = null)
            : base(
                hasreverse, numberofshafts, gen, spools, egt, isp, numberofcycles, propellants, oxidisers, manufacturer,
                model, serialnumber, maxpower, operatingtime, parentaircraft, fuelflow, stat)
        {
            _precoolant = precoolant ?? "none";
        }
    }
}