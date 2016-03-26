using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Mapping
{
    public class TurbofanMap : EntityMap<Turbofan>
    {
        public TurbofanMap()
        {
            Map(x => x.BypassRatio).Not.Nullable();
            Map(x => x.IsGeared).Not.Nullable();
        }
    }
}