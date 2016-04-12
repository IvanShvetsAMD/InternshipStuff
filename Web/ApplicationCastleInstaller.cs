using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using FluentNHibernate.Conventions.AcceptanceCriteria;
using NHibernate;
using Repository.Implemetations;
using Repository.Interfaces;

namespace Web
{
    public class ApplicationCastleInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For(typeof(IRepository<>))
                    .ImplementedBy(typeof(Repository.Implemetations.Repository<>))
                    .LifestylePerWebRequest());

            container.Register(
                Component.For(typeof(IAircraftRegistryRepository))
                    .ImplementedBy(typeof(AircraftRegistryRepository))
                    .LifestylePerWebRequest());

            container.Register(Component.For(typeof(ISession)).UsingFactoryMethod(x => SessionGenerator.Instance.GetSession()));

            var controllerTypes =
                Assembly.GetExecutingAssembly().GetTypes().Where(x => x.BaseType == typeof(Controller));

            foreach (var controllerType in controllerTypes)
            {
                container.Register(Component.For(controllerType).LifestylePerWebRequest());
            }
        }
    }
}