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
    internal class GasCompartmentRepository : Repository<GasCompartment>, IGasCompartmentRepository
    {
        public void AddGas(float delta, long id)
        {
            using (ITransaction transaction = _session.BeginTransaction())
            {
                var gasCompartment = _session.Load<GasCompartment>(id);

                gasCompartment.AddGas(delta);

                transaction.Commit();
            }
        }

        public void RemoveGas(float delta, long id)
        {
            using (ITransaction transaction = _session.BeginTransaction())
            {
                var gasCompartment = _session.Load<GasCompartment>(id);

                gasCompartment.RemoveGas(delta);

                transaction.Commit();
            }
        }
    }
}