using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;

namespace Domain.Mapping
{
    class TurbineBladeMap: EntityMap<TurbineBlade>
    {
        public TurbineBladeMap()
        {
            Map(x => x.HasCoolingChannels).Not.Nullable();
            Map(x => x.MaxTemp).Not.Nullable();
        }
    }
}
