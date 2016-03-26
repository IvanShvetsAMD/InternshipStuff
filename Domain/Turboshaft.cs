using System.Collections.Generic;

namespace Domain
{
    public sealed class Turboshaft : TurbineEngine
    {
        public float GearingRatio { get; private set; }
        public float MaxTorque { get; private set; }

        public void IncreaseGearingRatio()
        {
        }

        public void DecreaseGearingratio()
        {
        }

        public sealed override void IncreasePower()
        {
            //check for torque limits
            base.IncreasePower();
        }

        public override void DecreasePower()
        {
            base.DecreasePower();
        }

        public override string ToString()
        {
            return string.Format("{0}, gearing ratio: {1}, max torque: {2}", base.ToString(), GearingRatio, MaxTorque);
        }

        public Turboshaft()
        {
        }

        public Turboshaft(float gearingratio, float maxtorque, bool hasreverse, uint numberofshafts, Generator gen,
            List<Spool> spools, int egt, int isp, int numberofcycles, List<Propellants> propellants,
            List<Oxidisers> oxidisers,
            string manufacturer, string model, string serialnumber,
            float maxpower, float operatingtime, string parentaircraftID, float fuelflow, OnOff stat)
            : base(
                hasreverse, numberofshafts, gen, spools, egt, isp, numberofcycles, propellants, oxidisers, manufacturer,
                model, serialnumber, maxpower, operatingtime, parentaircraftID, fuelflow, stat)
        {
            GearingRatio = gearingratio;
            MaxTorque = maxtorque;
        }
    }
}