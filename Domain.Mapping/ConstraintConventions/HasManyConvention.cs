using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;

namespace Domain.Mapping.ConstraintConventions
{
    public class HasManyConvention : IHasManyConvention
    {
        public void Apply(IOneToManyCollectionInstance instance)
        {
            instance.Key.ForeignKey($"FK_{instance.Member.Name}_{instance.EntityType.Name}");
        }
    }
}
