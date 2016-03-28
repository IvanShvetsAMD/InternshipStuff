using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Mapping
{
    public class JetEngineMap : EntityMap<JetEngine>
    {
        public JetEngineMap()
        {
            Map(x => x.EGT).Not.Nullable();
            Map(x => x.Isp).Not.Nullable();
            Map(x => x.NumberOfCycles).Not.Nullable();
            HasMany<Propellants>(x => x.Propellants).CollectionType<Propellants>().Element("PropellantId").AsBag();
            HasMany<Oxidisers>(x => x.Oxidisers).CollectionType<Oxidisers>().Element("OxidiserId").AsBag();

            
        }
    }
}