using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;

namespace Domain.Mapping
{
    public class VariableGeometryWingMap : SubclassMap<VariableGeometryWing>
    {
        public VariableGeometryWingMap()
        {
            Id(x => x.Id);
            Map(x => x.FuelCapacity).Not.Nullable();
            Map(x => x.RootThickness).Not.Nullable();
            Map(x => x.WingAngle).Not.Nullable();
            Map(x => x.MaxBackSweepAngle).Not.Nullable();
            Map(x => x.MaxForwardSweepAngle).Not.Nullable();
            References(x => x.ParentfFixedWingAircraft).Nullable();
        }
    }
}