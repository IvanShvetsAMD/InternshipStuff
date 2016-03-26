using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Mapping
{
    public class RamjetMap : EntityMap<Ramjet>
    {
        public RamjetMap()
        {
            Map(x => x.HasSupersonicCombustion).Not.Nullable();
        }
    }
}