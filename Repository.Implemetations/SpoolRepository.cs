using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Repository.Interfaces;

namespace Repository.Implemetations
{
    internal class SpoolRepository : Repository<Spool> , ISpoolRepository
    {
    }
}