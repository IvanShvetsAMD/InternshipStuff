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

        List<AicraftInfoAndDateOfRegistrationDto> GetAicraftInfoAndDateOfPenultimateRegistrationDtos(int years);

        List<AicraftInfoAndDateOfRegistrationDto> GetAicraftInfoAndLastDateOfRegistrationDtos(int years);

        List<AicraftInfoAndIfRegisteredBoolDto> GetAicraftInfoAndIfRegisteredBoolDto();

        List<string> GetAircraftRegisteredInTwoSpecificYears(int yearOne, int yearTwo);

        List<AircraftRegistry> GetAllAircraftRegistries();

        void DeleteById(long id, string serialnumber = null, string registration = null, DateTime registrationdate = default(DateTime), bool hascrashed = false);
    }
}