using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Domain.Dto;

namespace Repository.Interfaces
{
    public interface IAircraftRegistryRepository : IRepository<AircraftRegistry>
    {
        List<AicraftInfoAndNumberOfTimesRegisteredDto> GetAicraftInfoAndNumberOfTimesRegistered();

        List<AicraftInfoAndDateOfRegistrationDto> GetAicraftInfoAndDateOfRegistrationDtos();
    }
}