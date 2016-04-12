using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Domain.Dto;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.Transform;
using Repository.Interfaces;

namespace Repository.Implemetations
{
    public class GasCompartmentRepository : Repository<GasCompartment>,  IGasCompartmentRepository
    {
        public List<GasCompatrmentsCountAndCapacityDto> GetCompartmetnsCountWithLowerCapacityThan(int capacity)
        {
            using (ITransaction transaction = session.BeginTransaction())
            {
                List<GasCompatrmentsCountAndCapacityDto> results;
                GasCompartment gasCompartmentAlias = null;
                GasCompatrmentsCountAndCapacityDto DTO = null;

                results = session.QueryOver<GasCompartment>(() => gasCompartmentAlias)
                    .SelectList(list => list
                        .SelectGroup(() => gasCompartmentAlias.Capacity).WithAlias(() => DTO.Capacity)
                        .SelectCount(() => gasCompartmentAlias.Capacity).WithAlias(() => DTO.Count))
                    .Where(Restrictions.Gt(Projections.Property(() => gasCompartmentAlias.Capacity), capacity))
                    .TransformUsing(Transformers.AliasToBean<GasCompatrmentsCountAndCapacityDto>())
                    .List<GasCompatrmentsCountAndCapacityDto>().ToList();


                transaction.Commit();
                return results;
            }
        }

        public List<long> GetCompartmentsWithLessThanDoubleTheAverageVolume()
        {
            using (ITransaction transaction = session.BeginTransaction())
            {
                List<long> results = null;
                GasCompartment gasCompartmentAlias = null;
                
                results = session.QueryOver<GasCompartment>(() => gasCompartmentAlias)
                    .WithSubquery
                    .WhereProperty(() => gasCompartmentAlias.CurrentVolume)
                    .Gt(QueryOver.Of<GasCompartment>().SelectList(list => list.SelectAvg(gc2 => gc2.CurrentVolume)))
                    .Select(gc => gc.Id)
                    .List<long>().ToList();


                transaction.Commit();
                return results;
            }
        }
    }
}