using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Repository.Interfaces;

namespace Repository.Implemetations
{
    internal class EngineRepository : Repository<Engine>, IEngineRepository
    {
    }

    internal class PistonEngineRepository : Repository<PistonEngine>, IPistonEngineRepository
    {
    }

    internal class JetEngineRepository : Repository<JetEngine>, IJetEngineRepository
    {
    }

    internal class RocketEngineRepository : Repository<RocketEngine>, IRocketEngineRepository
    {
    }

    internal class SolidFuelRocketEngineRepository : Repository<SolidFuelRocketEngine>, ISolidFuelRocketEngineRepository
    {
    }

    internal class RamjetRepository : Repository<Ramjet>, IRamjetRepository
    {
    }

    internal class TurbineEngineRepository : Repository<TurbineEngine>, ITurbineEngineRepository
    {
    }

    internal class TurbofanRepository : Repository<Turbofan>, ITurbofanRepository
    {
    }

    internal class TurbojetRepository : Repository<Turbojet>, ITurbojetRepository
    {
    }

    internal class TurboshaftRepository : Repository<Turboshaft>, ITurboshaftRepository
    {
    }

    internal class PropellantRepository : Repository<Propellant>, IPropellantRepository
    {
    }

    internal class OxidiserRepository : Repository<Oxidiser>, IOxidiserRepository
    {
    }
}