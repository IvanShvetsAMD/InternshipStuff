using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Mapping
{
    public class TurboShaftMap : EntityMap<Turboshaft>
    {
        public TurboShaftMap()
        {
            Map(x => x.GearingRatio).Not.Nullable();
            Map(x => x.MaxTorque).Not.Nullable();
        }
    }
}