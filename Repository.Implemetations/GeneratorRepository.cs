using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using NHibernate;
using Repository.Interfaces;

namespace Repository.Implemetations
{
    internal class GeneratorRepository : Repository<Generator>, IGeneratorRepository
    {
        public void IncreaseCurrent(float delta, long id)
        {
            using (ITransaction transaction = _session.BeginTransaction())
            {
                var generator = _session.Load<Generator>(id);
                generator.IncreaseCurrent(delta);
                transaction.Commit();
            }
        }


        public void IncreaseVoltage (float delta, long id)
        {
            using (ITransaction transaction = _session.BeginTransaction())
            {
                var generator = _session.Load<Generator>(id);
                generator.IncreaseVoltage(delta);
                transaction.Commit();
            }
        }
    }
}