using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Mapping;

namespace Domain.Mapping
{
    public class AircraftMap : EntityMap<Aircraft>
    {
        public AircraftMap()
        {
            Map(x => x.IsOperational).Not.Nullable();
            Map(x => x.Manufacturer).Not.Nullable();
            Map(x => x.Model).Not.Nullable();
            Map(x => x.MaxTakeoffWeight).Not.Nullable();
            Map(x => x.SerialNumber).Not.Nullable();
            Map(x => x.Vne).Not.Nullable();
        }
    }

    public class PoweredAircraftMap : EntityMap<PoweredAircraft>
    {
        public PoweredAircraftMap()
        {
            Map(x => x.FuelCapacity).Not.Nullable();
        }
    }

    public class LighterThanAirAricraftMap : EntityMap<LighterThanAirAircraft>
    {
        public LighterThanAirAricraftMap()
        {
            Map(x => x.BallastMass).Not.Nullable();
            Map(x => x.GasType).Not.Nullable();
            Map(x => x.GasVolume).Not.Nullable();
        }
    }

    public class HeavierThanAirAircraftMap : EntityMap<HeavierThanAirAircraft>
    {
        public HeavierThanAirAircraftMap()
        {
            
        }
    }

    public class FixedWingAircraftMap : EntityMap<FixedWingAircraft>
    {
        public FixedWingAircraftMap()
        {
            Map(x => x.CruiseSpeed).Not.Nullable();
            Map(x => x.StallSpeed).Not.Nullable();
            Map(x => x.Wings).Not.Nullable();
        }
    }

    public class RotorcraftMap : EntityMap<RotorCraft>
    {
        public RotorcraftMap()
        {
            Map(x => x.NumberOfRotors).Not.Nullable();
            Map(x => x.RotorType).Not.Nullable();
        }
    }
}