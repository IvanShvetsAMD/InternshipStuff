using Domain;
using Domain.Mapping;
using Domain.Mapping.ConstraintConventions;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Conventions.Helpers.Builders;
using NHibernate;
using NHibernate.Tool.hbm2ddl;

namespace Repository.Implemetations
{
    class SessionGenerator
    {
        public static SessionGenerator Instance
        {
            get { return _sessionGenerator; }
        }

        public ISession GetSession()
        {
            return SessionFactory.OpenSession();
        }

        private static readonly SessionGenerator _sessionGenerator = new SessionGenerator();

        private static readonly ISessionFactory SessionFactory = CreateSessionFactory();

        private static ISessionFactory CreateSessionFactory()
        {
            var configuration = Fluently.Configure()
               .Database(MsSqlConfiguration.MsSql2012
                  .ConnectionString(
                     builder =>
                        builder.Database("Aviation")
                           .Server(@"MDDSK40043\SQLEXPRESS")
                           //.Server(@"DESKTOP-CQKKU19\SQLEXPRESS")
                           .TrustedConnection()))
               .Mappings(cfg => CreateMappings(cfg))
               .ExposeConfiguration(
                  cfg => new SchemaUpdate(cfg).Execute(true, true));

            var conf = configuration.BuildConfiguration();

            return conf.BuildSessionFactory();
        }

        private static void CreateMappings(MappingConfiguration mappingConfiguration)
        {
            var assembly = typeof(EntityMap<Entity>).Assembly;

            mappingConfiguration.FluentMappings.AddFromAssembly(assembly);
            mappingConfiguration.HbmMappings.AddFromAssembly(assembly);
            mappingConfiguration.FluentMappings.Conventions.AddFromAssemblyOf<PrimaryKeyConvention>();
            mappingConfiguration.FluentMappings.Conventions.AddFromAssemblyOf<HasManyConvention>();
            mappingConfiguration.FluentMappings.Conventions.AddFromAssemblyOf<HasOneConvention>();
            mappingConfiguration.FluentMappings.Conventions.AddFromAssemblyOf<JoinedSubclassConvention>();
            mappingConfiguration.FluentMappings.Conventions.AddFromAssemblyOf<ReferencesConvention>();
        }

        private SessionGenerator()
        {
        }
    }
}