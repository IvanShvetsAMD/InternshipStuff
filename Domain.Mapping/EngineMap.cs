using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Mapping
{
    public class EngineMap : EntityMap<Engine>
    {
        public EngineMap()
        {
            Id(x => x.Id);
            Map(x => x.SerialNumber).Not.Nullable();
            Map(x => x.Manufacturer).Not.Nullable();
            Map(x => x.Model).Not.Nullable();
            Map(x => x.OperatingTime).Not.Nullable();
            Map(x => x.OnOffStatus).CustomType<OnOff>().Not.Nullable();
            References(x => x.ParentAircraft).Nullable();
        }
    }
}