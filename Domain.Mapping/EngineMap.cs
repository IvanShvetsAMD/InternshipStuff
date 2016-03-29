using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
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
            Map(x => x.ParentAircraftId).Not.Nullable();
        }
    }

    public class PistonEngineMap : EntityMap<PistonEngine>
    {
        public PistonEngineMap()
        {
            Map(x => x.Mixture).Not.Nullable();
            Map(x => x.NumberOfPistons).Not.Nullable();
            Map(x => x.Volume).Not.Nullable();
        }
    }

    public class JetEngineMap : EntityMap<JetEngine>
    {
        public JetEngineMap()
        {
            Map(x => x.NumberOfCycles).Not.Nullable();
            Map(x => x.EGT).Not.Nullable();
            Map(x => x.Isp).Not.Nullable();
        }
    }

    public class RocketEngineMap : EntityMap<RocketEngine>
    {
        public RocketEngineMap()
        {
            Map(x => x.IsReignitable).Not.Nullable();
            Map(x => x.NozzleBellType).Not.Nullable();
        }
    }

    public class SolidFuelRocketEngineMap : EntityMap<SolidFuelRocketEngine>
    {
        public SolidFuelRocketEngineMap()
        {
            Map(x => x.CurrentPower).Not.Nullable();
            Map(x => x.MaxPower).Not.Nullable();
        }
    }

    public class TurbineEngineMap : EntityMap<TurbineEngine>
    {
        public TurbineEngineMap()
        {
            //Map(x => x.Generator).Not.Nullable();
            Map(x => x.HasReverse).Not.Nullable();
            Map(x => x.NumberOfShafts).Not.Nullable();
        }
    }

    public class RamjetRepository : EntityMap<Ramjet>
    {
        public RamjetRepository()
        {
            Map(x => x.HasSupersonicCombustion).Not.Nullable();
        }
    }

    public class TurbofanMap : EntityMap<Turbofan>
    {
        public TurbofanMap()
        {
            Map(x => x.BypassRatio).Not.Nullable();
            Map(x => x.IsGeared).Not.Nullable();
        }
    }

    public class TurboshaftMap : EntityMap<Turboshaft>
    {
        public TurboshaftMap()
        {
            Map(x => x.GearingRatio).Not.Nullable();
            Map(x => x.MaxTorque).Not.Nullable();
        }
    }

    public class TurbojetMap : EntityMap<Turbojet>
    {
        public TurbojetMap()
        {
            Map(x => x.Precoolant).Not.Nullable();
        }
    }

}