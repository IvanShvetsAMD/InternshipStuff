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

            //misc
            Kernel.Bind<IGasCompartmentRepository>().To<GasCompartmentRepository>();
            Kernel.Bind<IGeneratorRepository>().To<GeneratorRepository>();

            //wings
            Kernel.Bind<IWingRepository>().To<WingRepository>();
            Kernel.Bind<IVariableGeometryWingRepository>().To<VariableGeometryWingRepository>();

            //engines
            Kernel.Bind<IEngineRepository>().To<EngineRepository>();
            Kernel.Bind<IPistonEngineRepository>().To<PistonEngineRepository>();
            Kernel.Bind<IJetEngineRepository>().To<JetEngineRepository>();
            Kernel.Bind<IRocketEngineRepository>().To<RocketEngineRepository>();
            Kernel.Bind<ISolidFuelRocketEngineRepository>().To<SolidFuelRocketEngineRepository>();
            Kernel.Bind<IRamjetRepository>().To<RamjetRepository>();
            Kernel.Bind<ITurbineEngineRepository>().To<TurbineEngineRepository>();
            Kernel.Bind<ITurbofanRepository>().To<TurbofanRepository>();
            Kernel.Bind<ITurbojetRepository>().To<TurbojetRepository>();
            Kernel.Bind<ITurboshaftRepository>().To<TurboshaftRepository>();
        }

        public static T Get<T>()
        {
            return Kernel.Get<T>();
        }
    }
}