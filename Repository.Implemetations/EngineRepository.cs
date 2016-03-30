using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using NHibernate;
using NHibernate.Util;
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
        //public new void Save(Turbojet engine)
        //{
        //    using (ITransaction transaction = session.BeginTransaction())
        //    {
        //        if (engine.Spools != null )
        //        {
        //            if (engine.Spools.Count != 0)
        //            {
        //                engine.Spools.ForEach(x => session.SaveOrUpdate(x));
        //            }
        //        }
        //        session.SaveOrUpdate(engine);

        //        transaction.Commit();
        //    }
        //}
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