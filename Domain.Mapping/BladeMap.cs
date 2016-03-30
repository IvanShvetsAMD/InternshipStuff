using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;

namespace Domain.Mapping
{
    public class BladeMap : EntityMap<Blade>
    {
        public BladeMap()
        {
            Map(x => x.Chord).Not.Nullable();
            Map(x => x.Length).Not.Nullable();
            Map(x => x.MaterialType).Not.Nullable();
        }
    }

    public class TurbineBladeMap : SubclassMap<TurbineBlade>
    {
        public TurbineBladeMap()
        {
            Map(x => x.HasCoolingChannels).Not.Nullable();
            Map(x => x.MaxTemp).Not.Nullable();
            References(x => x.ParentSpool);
        }
    }
    public class RotorBladeMap : SubclassMap<RotorBlade>
    {
        public RotorBladeMap()
        {
            Map(x => x.HasSupersonicTip).Not.Nullable();
            References(x => x.ParentAircraft);
        }
    }
}