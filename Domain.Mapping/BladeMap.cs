using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Mapping
{
    class BladeMap :EntityMap<Blade>
    {
        public BladeMap()
        {
            Id(x => x.Id).Column("BladeID");
            Map(x => x.Length).Not.Nullable();
            Map(x => x.Chord).Not.Nullable();
            Map(x => x.MaterialType).Not.Nullable();
        }
    }
}