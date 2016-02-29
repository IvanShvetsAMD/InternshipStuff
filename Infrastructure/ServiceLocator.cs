using Interfaces;
using ActionImplementations;
using Ninject;

namespace Infrastructure
{
    internal static class ServiceLocator
    {
        private static readonly IKernel Kernel = new StandardKernel();

        public static void RegisterAll()
        {
            Kernel.Bind<IAddEngines>().To<TurbineEngineInstaller>();
        }

        public static T Get<T>()
        {
            return Kernel.Get<T>();
        }
    }
}