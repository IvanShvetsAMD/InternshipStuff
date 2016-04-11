using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Mapping
{
    public class PropellantMap : EntityMap<Propellant>
    {
        public PropellantMap()
        {
            Id(x => x.Id);
            Map(x => x.IntValue);
            Map(x => x.Name);
        }
    }
}