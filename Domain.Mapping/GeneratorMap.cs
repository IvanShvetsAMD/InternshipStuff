using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Mapping
{
    class GeneratorMap : EntityMap<Generator>
    {
        public GeneratorMap()
        {
            Table("GasCompartment");
            Id(x => x.Id).Column("GeneratorID");
            Map(x => x.OutputCurrent).Not.Nullable();
            Map(x => x.OutputVoltage).Not.Nullable();
            References(x => x.ParentEngine).Nullable();
        }
    }
}