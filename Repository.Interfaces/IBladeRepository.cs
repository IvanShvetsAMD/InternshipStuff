﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace Repository.Interfaces
{
    public interface IBladeRepository : IRepository<Blade>
    {
    }

    public interface ITurbineBladeRepository : IRepository<TurbineBlade>
    {
    }

    public interface IRotorBladeRepository : IRepository<RotorBlade>
    {
    }
}