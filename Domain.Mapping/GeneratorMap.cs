using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Mapping
{
    public class GeneratorMap : EntityMap<Generator>
    {
        public GeneratorMap()
        {
            Map(x => x.OutputCurrent).Not.Nullable();
            Map(x => x.OutputVoltage).Not.Nullable();
        }
    }
}