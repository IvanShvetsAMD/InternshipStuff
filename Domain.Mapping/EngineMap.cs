using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using NHibernate.Mapping;

namespace Domain.Mapping
{
    public class EngineMap : EntityMap<Engine>
    {
        public EngineMap()
        {
            Map(x => x.CurrentPower).Not.Nullable();
            Map(x => x.FuelFlow).Not.Nullable();
            Map(x => x.Manufacturer).Not.Nullable();
            Map(x => x.Model).Not.Nullable();
            Map(x => x.MaxPower).Not.Nullable();
            Map(x => x.OnOffStatus).Not.Nullable();
            Map(x => x.OperatingTime).Not.Nullable();
            Map(x => x.SerialNumber).Not.Nullable();
            References(x => x.ParentAircraft);
        }
    }

    public class PistonEngineMap : SubclassMap<PistonEngine>
    {
        public PistonEngineMap()
        {
            Map(x => x.Mixture).Not.Nullable();
            Map(x => x.NumberOfPistons).Not.Nullable();
            Map(x => x.Volume).Not.Nullable();
        }
    }

    public class JetEngineMap : SubclassMap<JetEngine>
    {
        public JetEngineMap()
        {
            Map(x => x.NumberOfCycles).Not.Nullable();
            Map(x => x.EGT).Not.Nullable();
            Map(x => x.Isp).Not.Nullable();
            HasMany(x => x.Propellants);
            HasMany(x => x.Oxidisers);
        }
    }

    public class PropellantMap : EntityMap<Propellant>
    {
        public PropellantMap()
        {
            Map(x => x.IntValue).Not.Nullable();
            Map(x => x.Name).Not.Nullable();
            References(x => x.ParentEngine);
        }
    }

    public class OxidiserMap : EntityMap<Oxidiser>
    {
        public OxidiserMap()
        {
            Map(x => x.IntValue).Not.Nullable();
            Map(x => x.Name).Not.Nullable();
            References(x => x.ParentEngine);
        }
    }

    public class RocketEngineMap : SubclassMap<RocketEngine>
    {
        public RocketEngineMap()
        {
            Map(x => x.IsReignitable).Not.Nullable();
            Map(x => x.NozzleBellType).Not.Nullable();
        }
    }

    public class SolidFuelRocketEngineMap : SubclassMap<SolidFuelRocketEngine>
    {
        public SolidFuelRocketEngineMap()
        {
            Map(x => x.CurrentPower).Not.Nullable();
            Map(x => x.MaxPower).Not.Nullable();
        }
    }

    public class TurbineEngineMap : SubclassMap<TurbineEngine>
    {
        public TurbineEngineMap()
        {
            Map(x => x.HasReverse).Not.Nullable();
            Map(x => x.NumberOfShafts).Not.Nullable();
            HasMany(x => x.Spools);
            HasOne(x => x.Generator);
        }
    }

    public class RamjetRepository : SubclassMap<Ramjet>
    {
        public RamjetRepository()
        {
            Map(x => x.HasSupersonicCombustion).Not.Nullable();
        }
    }

    public class TurbofanMap : SubclassMap<Turbofan>
    {
        public TurbofanMap()
        {
            Map(x => x.BypassRatio).Not.Nullable();
            Map(x => x.IsGeared).Not.Nullable();
        }
    }

    public class TurboshaftMap : SubclassMap<Turboshaft>
    {
        public TurboshaftMap()
        {
            Map(x => x.GearingRatio).Not.Nullable();
            Map(x => x.MaxTorque).Not.Nullable();
        }
    }

    public class TurbojetMap : SubclassMap<Turbojet>
    {
        public TurbojetMap()
        {
            Map(x => x.Precoolant).Not.Nullable();
        }
    }
}