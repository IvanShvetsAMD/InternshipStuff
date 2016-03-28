﻿using System;
using System.Collections.Generic;

namespace Domain
{
    public class Turboshaft : TurbineEngine
    {
        private readonly float _gearingRatio;
        private readonly float _maxTorque;

        public virtual float GearingRatio => _gearingRatio;

        public virtual float MaxTorque => _maxTorque;

        public virtual void IncreaseGearingRatio()
        {
        }

        public virtual void DecreaseGearingratio()
        {
        }

        public virtual void IncreasePower()
        {
            //check for torque limits
            base.IncreasePower();
        }

        public virtual void DecreasePower()
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
            List<Spool> spools, int egt, int isp, int numberofcycles, List<Propellant> propellants,
            List<Oxidiser> oxidisers,
            string manufacturer, string model, string serialnumber,
            float maxpower, float operatingtime, Aircraft parentaircraft, float fuelflow, OnOff stat)
            : base(
                hasreverse, numberofshafts, gen, spools, egt, isp, numberofcycles, propellants, oxidisers, manufacturer,
                model, serialnumber, maxpower, operatingtime, parentaircraft, fuelflow, stat)
        {
            _gearingRatio = gearingratio;
            _maxTorque = maxtorque;
        }
    }
}