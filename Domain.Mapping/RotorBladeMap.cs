using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Mapping
{
    public class RotorBladeMap : EntityMap<RotorBlade>
    {
        public RotorBladeMap()
        {
            Map(x => x.HasSupersonicTip).Not.Nullable();
            References(x => x.ParentRotorCraft).Nullable();
        }
    }
}