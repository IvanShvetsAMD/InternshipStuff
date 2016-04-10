using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;

namespace Domain.Mapping.ConstraintConventions
{
    public class HasOneConvention : IHasOneConvention
    {
        public void Apply(IOneToOneInstance instance)
        {
            instance.ForeignKey($"FK_{instance.Name}_{instance.EntityType.Name}");
        }
    }
}
