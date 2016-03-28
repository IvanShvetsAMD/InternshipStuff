using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Mapping
{
    public class PoweredAircraftMap : EntityMap<PoweredAircraft>
    {
        public PoweredAircraftMap()
        {
            Map(x => x.FuelCapacity).Not.Nullable();
            HasMany(x => x.Engines).Cascade.SaveUpdate();
        }
    }
}