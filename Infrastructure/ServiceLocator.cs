using ActionImplementations;
using Interfaces;
using Ninject;
using Repository.Implemetations;
using Repository.Interfaces;

namespace Infrastructure
{
    internal static class ServiceLocator
    {
        private static readonly IKernel Kernel = new StandardKernel();

        public static void RegisterAll()
        {
            Kernel.Bind<IAddEngines>().To<TurbineEngineInstaller>();
            Kernel.Bind<IGasCompartmentRepository>().To<GasCompartmentRepository>();
            Kernel.Bind<IGeneratorRepository>().To<GeneratorRepository>();
        }

        public static T Get<T>()
        {
            return Kernel.Get<T>();
        }
    }
}