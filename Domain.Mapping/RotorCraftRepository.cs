using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Mapping
{
    public class RotorCraftMap : EntityMap<RotorCraft>
    {
        public RotorCraftMap()
        {
            Map(x => x.RotorType).Not.Nullable();
        }
    }
}