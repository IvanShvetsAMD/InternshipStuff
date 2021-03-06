﻿using System.Collections.Generic;

namespace Domain
{
    public class Turbojet : TurbineEngine
    {
        public virtual string Precoolant { get; }

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

        public Turbojet(bool hasreverse, int numberofshafts, Generator gen, List<Spool> spools, int egt, int isp,
            int numberofcycles, List<Propellant> propellants, List<Oxidiser> oxidisers,
            string manufacturer, string model, string serialnumber,
            float maxpower, float operatingtime, PoweredAircraft parentaircraft, float fuelflow, OnOff stat,
            string precoolant = null)
            : base(
                hasreverse, numberofshafts, gen, spools, egt, isp, numberofcycles, propellants, oxidisers, manufacturer,
                model, serialnumber, maxpower, operatingtime, parentaircraft, fuelflow, stat)
        {
            Precoolant = precoolant ?? "none";
        }
    }
}