using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Repository.Interfaces;

namespace Repository.Implemetations
{
    internal class BladeRepository : Repository<Blade>, IBladeRepository
    {
    }

    internal class TurbineBladeRepository : Repository<TurbineBlade>, ITurbineBladeRepository
    {
    }

    internal class RotorBladeRepository : Repository<RotorBlade>, IRotorBladeRepository
    {
    }
}