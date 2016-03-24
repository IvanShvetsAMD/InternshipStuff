using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;

namespace Domain.Mapping
{
    public class GasCompartmentMap : EntityMap<GasCompartment>
    {
        public GasCompartmentMap()
        {
            Id(x => x.Id).Column("GasCompartmentID");
            Map(x => x.Capacity).Not.Nullable();
            Map(x => x.CurrentVolume).Not.Nullable();
        }
    }
}