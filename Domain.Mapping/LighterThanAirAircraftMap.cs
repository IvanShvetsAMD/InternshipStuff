using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Mapping
{
    public class LighterThanAirAircraftMap : EntityMap<LighterThanAirAircraft>
    {
        public LighterThanAirAircraftMap()
        {
            Map(x => x.BallastMass).Not.Nullable();
            Map(x => x.GasType).Not.Nullable();
        }
    }
}