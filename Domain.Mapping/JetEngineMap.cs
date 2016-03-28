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
            HasMany<Propellant>(x => x.Propellants).Cascade.SaveUpdate();//.CollectionType<Propellant>().Element("PropellantId").AsBag();
            HasMany<Oxidiser>(x => x.Oxidisers).Cascade.SaveUpdate();//.CollectionType<OxidisersEnum>().Element("OxidiserId").AsBag();
        }
    }
}