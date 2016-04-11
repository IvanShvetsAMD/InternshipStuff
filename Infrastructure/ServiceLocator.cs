using System.Runtime.InteropServices;
using ActionImplementations;
using Interfaces;
using Ninject;
using Repository.Implemetations;
using Repository.Interfaces;
using System.Web;

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
            Kernel.Bind<IPropellantRepository>().To<PropellantRepository>();
            Kernel.Bind<IOxidiserRepository>().To<OxidiserRepository>();
            Kernel.Bind<IAircraftRegistryRepository>().To<AircraftRegistryRepository>();

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

            //airplanes
            Kernel.Bind<IAircraftRepository>().To<AircraftRepository>();
            Kernel.Bind<IPoweredAircraftRepository>().To<PoweredAircraftRepository>();
            Kernel.Bind<ILighterThanAirAircraftRepository>().To<LighterThanAirAircraftRepository>();
            Kernel.Bind<IHeavierThanAirAircraftRepository>().To<HeavierThanAirAircraftRepository>();
            Kernel.Bind<IFixedWingAircraftRepository>().To<FixedWingAircraftRepository>();
            Kernel.Bind<IRotorCraftRepository>().To<RotorCraftRepository>();

            //blades
            Kernel.Bind<IBladeRepository>().To<BladeRepository>();
            Kernel.Bind<ITurbineBladeRepository>().To<TurbineBladeRepository>();
            Kernel.Bind<IRotorBladeRepository>().To<RotorBladeRepository>();

            //spool
            Kernel.Bind<ISpoolRepository>().To<SpoolRepository>();

        }

        public static T Get<T>()
        {
            return Kernel.Get<T>();
        }
    }
}