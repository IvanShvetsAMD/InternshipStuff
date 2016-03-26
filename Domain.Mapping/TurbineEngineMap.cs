using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Mapping
{
    public class TurbineEngineMap : EntityMap<TurbineEngine>
    {
        public TurbineEngineMap()
        {
            Map(x => x.HasReverse).Not.Nullable();
            Map(x => x.NumberOfShafts).Not.Nullable();
        }
    }
}