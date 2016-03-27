using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Mapping
{
    public class FixedWingAircraftMap : EntityMap<FixedWingAircraft>
    {
        public FixedWingAircraftMap()
        {
            Map(x => x.CruiseSpeed).Not.Nullable();
            Map(x => x.StallSpeed).Not.Nullable();
            HasMany(x => x.Wings);
        }
    }
}