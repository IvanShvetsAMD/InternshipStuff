using System.Linq;
using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;

namespace Domain.Mapping.ConstraintConventions
{
    public class JoinedSubclassConvention : IJoinedSubclassConvention
    {
        public void Apply(IJoinedSubclassInstance instance)
        {
            instance.Key.ForeignKey($"FK_{instance.EntityType.Name}_{instance.EntityType.BaseType?.Name}");
        }
    }
}
