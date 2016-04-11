using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Mapping
{
    public class OxidiserMap : EntityMap<Oxidiser>
    {
        public OxidiserMap()
        {
            Id(x => x.Id);
            Map(x => x.IntValue);
            Map(x => x.Name);
        }
    }
}