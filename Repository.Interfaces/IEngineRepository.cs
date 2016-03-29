using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace Repository.Interfaces
{
    public interface IEngineRepository : IRepository<Engine>
    {
    }

    public interface IPistonEngineRepository : IRepository<PistonEngine>
    {
    }

    public interface IJetEngineRepository : IRepository<JetEngine>
    {
    }

    public interface IRocketEngineRepository : IRepository<RocketEngine>
    {
    }

    public interface ISolidFuelRocketEngineRepository : IRepository<SolidFuelRocketEngine>
    {
    }

    public interface IRamjetRepository : IRepository<Ramjet>
    {
    }

    public interface ITurbineEngineRepository : IRepository<TurbineEngine>
    {
    }

    public interface ITurbofanRepository : IRepository<Turbofan>
    {
    }

    public interface ITurbojetRepository : IRepository<Turbojet>
    {
    }

    public interface ITurboshaftRepository : IRepository<Turboshaft>
    {
    }
}