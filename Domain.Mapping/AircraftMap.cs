using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Mapping
{
    public class AircraftMap : EntityMap<Aircraft>
    {
        public AircraftMap()
        {
            Id(x => x.Id);
            Map(x => x.SerialNumber).Not.Nullable();
            Map(x => x.IsOperational).Not.Nullable();
            Map(x => x.Manufacturer).Not.Nullable();
            Map(x => x.Model).Not.Nullable();
            Map(x => x.MaxTakeoffWeight).Not.Nullable();
            Map(x => x.Vne).Not.Nullable();
            //HasMany(x => x.AviationAdministrations);
        }
    }
}