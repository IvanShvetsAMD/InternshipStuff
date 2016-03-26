using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Mapping
{
    public class VariableGeometryWingMap : EntityMap<VariableGeometryWing>
    {
        public VariableGeometryWingMap()
        {
            Map(x => x.MaxBackSweepAngle).Not.Nullable();
            Map(x => x.MaxForwardSweepAngle).Not.Nullable();
        }
    }
}