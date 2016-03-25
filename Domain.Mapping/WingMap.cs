using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Mapping
{
    class WingMap :EntityMap<Wing>
    {
        public WingMap()
        {
            Id(x => x.Id);
            Map(x => x.FuelCapacity).Not.Nullable();
            Map(x => x.RootThickness).Not.Nullable();
            Map(x => x.WingAngle).Not.Nullable();
        }
    }
}