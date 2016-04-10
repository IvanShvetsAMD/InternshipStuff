using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace Repository.Interfaces
{
    public interface IAircraftRepository : IRepository<Aircraft>
    {
    }

    public interface IPoweredAircraftRepository : IRepository<PoweredAircraft>
    {
    }

    public interface ILighterThanAirAircraftRepository : IRepository<LighterThanAirAircraft>
    {
    }

    public interface IHeavierThanAirAircraftRepository : IRepository<HeavierThanAirAircraft>
    {
    }

    public interface IRotorCraftRepository : IRepository<RotorCraft>
    {
    }

    public interface IFixedWingAircraftRepository : IRepository<FixedWingAircraft>
    {
        FixedWingAircraft LoadAircaftById(long Id);
    }
}