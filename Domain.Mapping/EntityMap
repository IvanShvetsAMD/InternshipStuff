using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Data;
using FluentNHibernate.Mapping;

namespace Domain.Mapping
{
    public abstract class EntityMap<TEntity> : ClassMap<TEntity> where TEntity : Entity
    {
        protected EntityMap()
        {
            Id(x => x.Id).GeneratedBy.HiLo("1000");
            DynamicUpdate();
        }
    }
}