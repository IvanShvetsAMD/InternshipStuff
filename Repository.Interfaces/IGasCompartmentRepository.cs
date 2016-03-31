using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Domain;
using Domain.Dto;

namespace Repository.Interfaces
{
    public interface IGasCompartmentRepository : IRepository<GasCompartment>
    {
        //void Save(GasCompartment entity);

        List<GasCompatrmentsCountAndCapacityDto> GetCompartmetnsCountWithLowerCapacityThan(int capacity);
    }
}