using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Domain.Mapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
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
                        builder.Database("AviationDB")
                           .Server(@"MDDSK40043\SQLEXPRESS")
                           .TrustedConnection()))
               .Mappings(cfg => CreateMappings(cfg))
               .ExposeConfiguration(
                  cfg => new SchemaUpdate(cfg).Execute(true, true));

            var conf = configuration.BuildConfiguration();

            return conf.BuildSessionFactory();
        }

        private static void CreateMappings(MappingConfiguration mappingConfiguration)
        {
            var assembly = typeof(GasCompartmentMap).Assembly;

            mappingConfiguration.FluentMappings.AddFromAssembly(assembly);
            mappingConfiguration.HbmMappings.AddFromAssembly(assembly);
        }

        private SessionGenerator()
        {
        }
    }
}