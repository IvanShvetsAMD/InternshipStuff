using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Mapping
{
    public class RocketEngineMap : EntityMap<RocketEngine>
    {
        public RocketEngineMap()
        {
            Map(x => x.IsReignitable).Not.Nullable();
            Map(x => x.NozzleBellType).Not.Nullable();
        }
    }
}