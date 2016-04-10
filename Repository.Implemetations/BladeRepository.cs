using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Domain.Dto;
using FluentNHibernate.Utils;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.Transform;
using Repository.Interfaces;

namespace Repository.Implemetations
{
    internal class BladeRepository : Repository<Blade>, IBladeRepository
    {
    }

    internal class TurbineBladeRepository : Repository<TurbineBlade>, ITurbineBladeRepository
    {
        public IList<TurbineBladeAndSpoolTypeInfoDto> GetTurbineBladeAndSpoolTypeInfoDtos()
        {
            using (ITransaction transaction = session.BeginTransaction())
            {
                TurbineBladeAndSpoolTypeInfoDto result = new TurbineBladeAndSpoolTypeInfoDto();
                TurbineBlade turbineBladeAlias = null;
                Spool spoolAlias = null;

                QueryOver<TurbineBlade> subquery =
                    QueryOver.Of<TurbineBlade>().Where(tb => tb.MaterialType.IsLike("%tungsten%")).Select(tb => tb.Id);
                
                var results = new List<TurbineBladeAndSpoolTypeInfoDto>();

                results = session.QueryOver<TurbineBlade>(() => turbineBladeAlias)
                    .JoinQueryOver(() => turbineBladeAlias.ParentSpool, () => spoolAlias)
                    .Where(() => spoolAlias.Id == turbineBladeAlias.ParentSpool.Id)
                    .WithSubquery.WhereProperty(() => turbineBladeAlias.Id)
                    .NotIn(subquery)
                    .And(
                        new OrExpression(
                            new InsensitiveLikeExpression(Projections.Property(() => turbineBladeAlias.MaterialType),
                                "%alloy%"),
                            Restrictions.Gt(Projections.Property(() => turbineBladeAlias.MaxTemp), 1400)))
                    .SelectList(list => list
                        .Select(tb => tb.Id).WithAlias(() => result.TubineBladeID)
                        .Select(() => turbineBladeAlias.ParentSpool.Id).WithAlias(() => result.ParentSpoolID)
                        .Select(() => turbineBladeAlias.HasCoolingChannels).WithAlias(() => result.HasCoolingChannels)
                        .Select(() => turbineBladeAlias.MaxTemp).WithAlias(() => result.MaxTemp)
                        .Select(() => turbineBladeAlias.MaterialType).WithAlias(() => result.MaterialType)
                        .Select(() => turbineBladeAlias.Length).WithAlias(() => result.Length)
                        .Select(() => turbineBladeAlias.Chord).WithAlias(() => result.Chord))
                    .TransformUsing(Transformers.AliasToBean<TurbineBladeAndSpoolTypeInfoDto>())
                    .List<TurbineBladeAndSpoolTypeInfoDto>().ToList();
                

                transaction.Commit();
                return results;
            }
        }

        public List<TurbineBladeCountDifferentiateOnCoolingChannelsDto> GetNumberOfBladesWithOrWitjoutCooling()
        {
            using (ITransaction transaction = session.BeginTransaction())
            {
                List<TurbineBladeCountDifferentiateOnCoolingChannelsDto> results;
                TurbineBladeCountDifferentiateOnCoolingChannelsDto DTO = null;
                TurbineBlade turbineBladeAlias = null;

                results = session.QueryOver<TurbineBlade>(() => turbineBladeAlias)
                    .SelectList(selectionList => selectionList
                        .SelectGroup(() => turbineBladeAlias.HasCoolingChannels).WithAlias(() => DTO.HasCoolingChannels)
                        .SelectCount(() => turbineBladeAlias.HasCoolingChannels).WithAlias(() => DTO.Count))
                    .TransformUsing(Transformers.AliasToBean<TurbineBladeCountDifferentiateOnCoolingChannelsDto>())
                    .List<TurbineBladeCountDifferentiateOnCoolingChannelsDto>().ToList();

                transaction.Commit();
                return results;
            }
        }

        public List<long> GetTubineBladesWithMaxTempInAVGorMAX()
        {
            using (ITransaction transaction = session.BeginTransaction())
            {
                List<long> results = null;
                TurbineBlade turbineBladeAlias = null;

                QueryOver<TurbineBlade> subqueryAVG =
                    QueryOver.Of<TurbineBlade>()
                        .SelectList(list => list.SelectMax(tb => tb.MaxTemp));

                QueryOver<TurbineBlade> subqueryMAX =
                    QueryOver.Of<TurbineBlade>()
                        .SelectList(list => list.SelectMax(tb => tb.MaxTemp));

                QueryOver<TurbineBlade> subqueryAVGMAX =
                    QueryOver.Of<TurbineBlade>(() => turbineBladeAlias)
                        .Select(Projections.Avg(Projections.Property(() => turbineBladeAlias.MaxTemp)))
                        .Select(Projections.Max(Projections.Property(() => turbineBladeAlias.MaxTemp)));

                results = session.QueryOver<TurbineBlade>(() => turbineBladeAlias)
                    //.Where(() => turbineBladeAlias.MaxTemp.IsIn(new object[] {subqueryMAX, subqueryAVG}))
                    .WithSubquery
                    .WhereProperty(() => turbineBladeAlias.MaxTemp).In(subqueryAVGMAX)
                    .Select(tb => tb.Id)
                    .List<long>().ToList();


                transaction.Commit();
                return results;
            }
        }
    }

    internal class RotorBladeRepository : Repository<RotorBlade>, IRotorBladeRepository
    {
    }
}