using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;

namespace Domain.Mapping.ConstraintConventions
{
    public class ReferencesConvention : IReferenceConvention
    {
        public void Apply(IManyToOneInstance instance)
        {
            instance.ForeignKey($"FK_{instance.EntityType.Name}_{instance.Name}");
        }
    }
}
