using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace Repository.Interfaces
{
    public interface IGeneratorRepository : IRepository<Generator>
    {
        void IncreaseCurrent(float delta, long id);
        void IncreaseVoltage(float delta, long id);
    }
}