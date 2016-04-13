using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ActionImplementations;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Interfaces;
using Repository.Implemetations;
using Repository.Interfaces;

namespace InfrastructureCastle
{
    public class RepositoriesInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IAddEngines>().ImplementedBy<TurbineEngineInstaller>());

            //misc
            container.Register(Component.For<IGasCompartmentRepository>().ImplementedBy<GasCompartmentRepository>().LifestylePerWebRequest());
            container.Register(Component.For<IGeneratorRepository>().ImplementedBy<GeneratorRepository>().LifestylePerWebRequest());
            container.Register(Component.For<IPropellantRepository>().ImplementedBy<PropellantRepository>().LifestylePerWebRequest());
            container.Register(Component.For<IOxidiserRepository>().ImplementedBy<OxidiserRepository>().LifestylePerWebRequest());
            container.Register(Component.For<IAircraftRegistryRepository>().ImplementedBy<AircraftRegistryRepository>().LifestylePerWebRequest());

            //wings
            container.Register(Component.For<IWingRepository>().ImplementedBy<WingRepository>().LifestylePerWebRequest());
            container.Register(Component.For<IVariableGeometryWingRepository>().ImplementedBy<VariableGeometryWingRepository>().LifestylePerWebRequest());

            //engines
            container.Register(Component.For<IEngineRepository>().ImplementedBy<EngineRepository>().LifestylePerWebRequest());
            container.Register(Component.For<IPistonEngineRepository>().ImplementedBy<PistonEngineRepository>().LifestylePerWebRequest());
            container.Register(Component.For<IJetEngineRepository>().ImplementedBy<JetEngineRepository>().LifestylePerWebRequest());
            container.Register(Component.For<IRocketEngineRepository>().ImplementedBy<RocketEngineRepository>().LifestylePerWebRequest());
            container.Register(Component.For<ISolidFuelRocketEngineRepository>().ImplementedBy<SolidFuelRocketEngineRepository>().LifestylePerWebRequest());
            container.Register(Component.For<IRamjetRepository>().ImplementedBy<RamjetRepository>().LifestylePerWebRequest());
            container.Register(Component.For<ITurbineEngineRepository>().ImplementedBy<TurbineEngineRepository>().LifestylePerWebRequest());
            container.Register(Component.For<ITurbofanRepository>().ImplementedBy<TurbofanRepository>().LifestylePerWebRequest());
            container.Register(Component.For<ITurboshaftRepository>().ImplementedBy<TurboshaftRepository>().LifestylePerWebRequest());
            container.Register(Component.For<ITurbojetRepository>().ImplementedBy<TurbojetRepository>().LifestylePerWebRequest());

            ////airplanes
            container.Register(Component.For<IAircraftRepository>().ImplementedBy<AircraftRepository>().LifestylePerWebRequest());
            container.Register(Component.For<IPoweredAircraftRepository>().ImplementedBy<PoweredAircraftRepository>().LifestylePerWebRequest());
            container.Register(Component.For<ILighterThanAirAircraftRepository>().ImplementedBy<LighterThanAirAircraftRepository>().LifestylePerWebRequest());
            container.Register(Component.For<IHeavierThanAirAircraftRepository>().ImplementedBy<HeavierThanAirAircraftRepository>().LifestylePerWebRequest());
            container.Register(Component.For<IFixedWingAircraftRepository>().ImplementedBy<FixedWingAircraftRepository>().LifestylePerWebRequest());
            container.Register(Component.For<IRotorCraftRepository>().ImplementedBy<RotorCraftRepository>().LifestylePerWebRequest());

            ////blades
            container.Register(Component.For<IBladeRepository>().ImplementedBy<BladeRepository>().LifestylePerWebRequest());
            container.Register(Component.For<ITurbineBladeRepository>().ImplementedBy<TurbineBladeRepository>().LifestylePerWebRequest());
            container.Register(Component.For<IRotorBladeRepository>().ImplementedBy<RotorBladeRepository>().LifestylePerWebRequest());

            ////spool
            container.Register(Component.For<ISpoolRepository>().ImplementedBy<SpoolRepository>().LifestylePerWebRequest());

            ////misc
            //container.Register(Component.For<IGasCompartmentRepository>().ImplementedBy<GasCompartmentRepository>());
            //container.Register(Component.For<IGeneratorRepository>().ImplementedBy<GeneratorRepository>());
            //container.Register(Component.For<IPropellantRepository>().ImplementedBy<PropellantRepository>());
            //container.Register(Component.For<IOxidiserRepository>().ImplementedBy<OxidiserRepository>());
            //container.Register(Component.For<IAircraftRegistryRepository>().ImplementedBy<AircraftRegistryRepository>());

            ////wings
            //container.Register(Component.For<IWingRepository>().ImplementedBy<WingRepository>());
            //container.Register(Component.For<IVariableGeometryWingRepository>().ImplementedBy<VariableGeometryWingRepository>());

            ////engines
            //container.Register(Component.For<IEngineRepository>().ImplementedBy<EngineRepository>());
            //container.Register(Component.For<IPistonEngineRepository>().ImplementedBy<PistonEngineRepository>());
            //container.Register(Component.For<IJetEngineRepository>().ImplementedBy<JetEngineRepository>());
            //container.Register(Component.For<IRocketEngineRepository>().ImplementedBy<RocketEngineRepository>());
            //container.Register(Component.For<ISolidFuelRocketEngineRepository>().ImplementedBy<SolidFuelRocketEngineRepository>());
            //container.Register(Component.For<IRamjetRepository>().ImplementedBy<RamjetRepository>());
            //container.Register(Component.For<ITurbineEngineRepository>().ImplementedBy<TurbineEngineRepository>());
            //container.Register(Component.For<ITurbofanRepository>().ImplementedBy<TurbofanRepository>());
            //container.Register(Component.For<ITurboshaftRepository>().ImplementedBy<TurboshaftRepository>());
            //container.Register(Component.For<ITurbojetRepository>().ImplementedBy<TurbojetRepository>());

            ////airplanes
            //container.Register(Component.For<IAircraftRepository>().ImplementedBy<AircraftRepository>());
            //container.Register(Component.For<IPoweredAircraftRepository>().ImplementedBy<PoweredAircraftRepository>());
            //container.Register(Component.For<ILighterThanAirAircraftRepository>().ImplementedBy<LighterThanAirAircraftRepository>());
            //container.Register(Component.For<IHeavierThanAirAircraftRepository>().ImplementedBy<HeavierThanAirAircraftRepository>());
            //container.Register(Component.For<IFixedWingAircraftRepository>().ImplementedBy<FixedWingAircraftRepository>());
            //container.Register(Component.For<IRotorCraftRepository>().ImplementedBy<RotorCraftRepository>());

            ////blades
            //container.Register(Component.For<IBladeRepository>().ImplementedBy<BladeRepository>());
            //container.Register(Component.For<ITurbineBladeRepository>().ImplementedBy<TurbineBladeRepository>());
            //container.Register(Component.For<IRotorBladeRepository>().ImplementedBy<RotorBladeRepository>());

            ////spool
            //container.Register(Component.For<ISpoolRepository>().ImplementedBy<SpoolRepository>());
        }
    }
}