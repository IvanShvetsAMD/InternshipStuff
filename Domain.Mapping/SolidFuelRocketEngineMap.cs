using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Mapping
{
    public class SolidFuelRocketEngineMap : EntityMap<SolidFuelRocketEngine>
    {
        public SolidFuelRocketEngineMap()
        {
            Map(x => x.CurrentPower).Not.Nullable();
            Map(x => x.MaxPower).Not.Nullable();
        }
    }
}