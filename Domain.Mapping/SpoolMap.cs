using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Mapping
{
    public class SpoolMap : EntityMap<Spool>
    {
        public SpoolMap()
        {
            Map(x => x.Type).Not.Nullable();
            HasMany(x => x.Blades).Cascade.All().Inverse();
            References(x => x.ParentEngine);
        }
    }
}