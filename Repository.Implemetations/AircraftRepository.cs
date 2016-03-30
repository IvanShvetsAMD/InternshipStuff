using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Repository.Interfaces;

namespace Repository.Implemetations
{
    internal class AircraftRepository : Repository<Aircraft>, IAircraftRepository
    {
    }

    internal class PoweredAircraftRepository : Repository<PoweredAircraft>, IPoweredAircraftRepository
    {
    }

    internal class LighterThanAirAircraftRepository : Repository<LighterThanAirAircraft>, ILighterThanAirAircraftRepository
    {
    }

    internal class HeavierThanAirAircraftRepository : Repository<HeavierThanAirAircraft>, IHeavierThanAirAircraftRepository
    {
    }

    internal class FixedWingAircraftRepository : Repository<FixedWingAircraft>, IFixedWingAircraftRepository
    {
        public FixedWingAircraft LoadAircaftById(long Id)
        {
            return LoadEntity<FixedWingAircraft>(Id);
        }
    }

    internal class RotorCraftRepository : Repository<RotorCraft>, IRotorCraftRepository
    {
    }
}