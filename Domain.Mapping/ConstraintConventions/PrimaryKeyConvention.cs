using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Helpers;
using FluentNHibernate.Conventions.Instances;

namespace Domain.Mapping.ConstraintConventions
{
    public class PrimaryKeyConvention : IIdConvention
    {
        public void Apply(IIdentityInstance instance)
        {
            instance.Column(instance.EntityType.Name + "Id");
            //instance.GeneratedBy.Native();
            //PrimaryKey.Name.Is(x => instance.EntityType.Name + "_Id");
        }
    }
}
