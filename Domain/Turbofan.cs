using System.Collections.Generic;

namespace Domain
{
    public class Turbofan : TurbineEngine
    {
        private readonly float _bypassRatio;
        private readonly bool _isGeared;

        public virtual float BypassRatio => _bypassRatio;

        public virtual bool IsGeared => _isGeared;

        public override string ToString()
        {
            return string.Format("{0}, bypass ratio: {1}, {2}", base.ToString(), BypassRatio,
                IsGeared ? "has a geared fan" : "has a direct drive fan");
        }

        public Turbofan(float bypassratio, bool isgeared, bool hasreverse, uint numberofshafts, Generator gen,
            List<Spool> spools, int egt, int isp, int numberofcycles, List<Propellant> propellants,
            List<Oxidiser> oxidisers,
            string manufacturer, string model, string serialnumber,
            float maxpower, float operatingtime, Aircraft parentaircraft, float fuelflow, OnOff stat)
            : base(
                hasreverse, numberofshafts, gen, spools, egt, isp, numberofcycles, propellants, oxidisers, manufacturer,
                model, serialnumber, maxpower, operatingtime, parentaircraft, fuelflow, stat)
        {
            _bypassRatio = bypassratio;
            _isGeared = isgeared;
        }

        public Turbofan()
        {
        }
    }
}