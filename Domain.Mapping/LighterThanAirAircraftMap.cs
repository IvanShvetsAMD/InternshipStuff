using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;

namespace Domain.Mapping
{
    public class LighterThanAirAircraftMap : SubclassMap<LighterThanAirAircraft>
    {
        public LighterThanAirAircraftMap()
        {
            //Id(x => x.Id).Column("AircraftId");
            Map(x => x.BallastMass).Not.Nullable();
            Map(x => x.GasType).Not.Nullable();
            HasMany(x => x.Compartments).Cascade.SaveUpdate();
        }
    }
}