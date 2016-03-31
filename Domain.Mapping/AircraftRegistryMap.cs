using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Mapping
{
    public class AircraftRegistryMap : EntityMap<AircraftRegistry>
    {
        public AircraftRegistryMap()
        {
            Map(x => x.AircraftRegistrationEntry).Not.Nullable();
            Map(x => x.HasCrashed).Not.Nullable();
            Map(x => x.RegistrationDate).CustomSqlType("Date").Not.Nullable();
            Map(x => x.SerialNumber).Not.Nullable();
        }
    }
}