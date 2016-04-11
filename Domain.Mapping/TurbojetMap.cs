using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Mapping
{
    public class TurbojetMap : EntityMap<Turbojet>
    {
        public TurbojetMap()
        {
            Map(x => x.Precoolant).Not.Nullable();
        }
    }
}