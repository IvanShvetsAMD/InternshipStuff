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

            //engines
            Kernel.Bind<IEngineRepository>().To<EngineRepository>();
            Kernel.Bind<IPistonEngineRepository>().To<PistonEngineRepository>();
            Kernel.Bind<IJetEngineRepository>().To<JetEngineRepository>();
            Kernel.Bind<IRocketEngineRepository>().To<RocketEngineRepository>();
            Kernel.Bind<ISolidFuelRocketEngineRepository>().To<SolidFuelRocketEngineRepository>();
            Kernel.Bind<IRamjetRepository>().To<RamjetRepository>();
            Kernel.Bind<ITurbineEngineRepository>().To<TurbineEngineRepository>();
            Kernel.Bind<ITurbofanRepository>().To<TurboFanRepository>();
            Kernel.Bind<ITurbojetRepository>().To<TurbojetRepository>();
            Kernel.Bind<ITurboshaftRepository>().To<TurboshaftRepository>();

            //aircraft
            Kernel.Bind<IAircraftRepository>().To<AircraftRepository>();
            Kernel.Bind<IPoweredAircraftRepository>().To<PoweredAircraftRepository>();
            Kernel.Bind<ILighterThanAirAircraftRepository>().To<ILighterThanAirAircraftRepository>();
            Kernel.Bind<IHeavierThanAirAircraftRepository>().To<HeavierThanAirAircraftRepository>();
            Kernel.Bind<IRotorCraftRepository>().To<RotorCraftRepository>();
            Kernel.Bind<IFixedWingAircraftRepository>().To<FixedWingAircraftRepository>();

            //wings
            Kernel.Bind<IWingRepository>().To<WingRepository>();
            Kernel.Bind<IVariableGeometryWingRepository>().To<VariableGeometryWingRepository>();
            
            //spools and blades
            Kernel.Bind<ISpoolRepository>().To<SpoolRepository>();
            Kernel.Bind<IBladeRepository>().To<BladeRepository>();
            Kernel.Bind<ITurbineBladeRepository>().To<TurbineBladeRepository>();
            Kernel.Bind<IRotorBladeRepository>().To<RotorBladeRepository>();
        }

        public static T Get<T>()
        {
            return Kernel.Get<T>();
        }
    }
}