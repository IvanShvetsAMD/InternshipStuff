﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Domain;

namespace Repository.Interfaces
{
    public interface IGasCompartmentRepository : IRepository<GasCompartment>
    {
        void Save(GasCompartment entity);
    }
}