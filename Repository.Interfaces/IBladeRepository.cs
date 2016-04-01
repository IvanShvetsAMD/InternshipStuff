using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Domain.Dto;

namespace Repository.Interfaces
{
    public interface IBladeRepository : IRepository<Blade>
    {
    }

    public interface ITurbineBladeRepository : IRepository<TurbineBlade>
    {
        IList<TurbineBladeAndSpoolTypeInfoDto> GetTurbineBladeAndSpoolTypeInfoDtos();

        List<TurbineBladeCountDifferentiateOnCoolingChannelsDto> GetNumberOfBladesWithOrWitjoutCooling();

        List<long> GetTubineBladesWithMaxTempInAVGorMAX();

    }

    public interface IRotorBladeRepository : IRepository<RotorBlade>
    {
    }
}