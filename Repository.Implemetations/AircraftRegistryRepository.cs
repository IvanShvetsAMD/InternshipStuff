using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Domain.Dto;
using NHibernate;
using NHibernate.Cfg.XmlHbmBinding;
using NHibernate.Criterion;
using NHibernate.Transform;
using Remotion.Linq.Clauses.ResultOperators;
using Repository.Interfaces;

namespace Repository.Implemetations
{
    internal class AircraftRegistryRepository : Repository<AircraftRegistry>, IAircraftRegistryRepository
    {
        public List<AicraftInfoAndNumberOfTimesRegisteredDto> GetAicraftInfoAndNumberOfTimesRegistered()
        {
            using (ITransaction transaction = session.BeginTransaction())
            {
                List<AicraftInfoAndNumberOfTimesRegisteredDto> results = null;
                Aircraft aircraftAlias = null;
                AircraftRegistry aircraftRegistryAlias = null;
                AicraftInfoAndNumberOfTimesRegisteredDto DTO = null;

                results = session.QueryOver<Aircraft>(() => aircraftAlias)
                    .SelectList(selectionList => selectionList
                        .SelectGroup(() => aircraftAlias.IsOperational).WithAlias(() => DTO.IsOperational)
                        .SelectGroup(() => aircraftAlias.SerialNumber).WithAlias(() => DTO.SerialNumber)
                        .SelectGroup(() => aircraftAlias.Vne).WithAlias(() => DTO.Vne)
                        .SelectGroup(() => aircraftAlias.Manufacturer).WithAlias(() => DTO.Manufacturer)
                        .SelectGroup(() => aircraftAlias.Model).WithAlias(() => DTO.Model)
                        .SelectGroup(() => aircraftAlias.MaxTakeoffWeight).WithAlias(() => DTO.MaxTakeoffWeight)
                        .SelectSubQuery(QueryOver.Of(() => aircraftRegistryAlias)
                                            .Where(() => aircraftRegistryAlias.SerialNumber == aircraftAlias.SerialNumber)
                                            .Select(Projections.Count(Projections.Property(() => aircraftRegistryAlias.RegistrationDate)))).WithAlias(() => DTO.Count))
                    .TransformUsing(Transformers.AliasToBean<AicraftInfoAndNumberOfTimesRegisteredDto>())
                    .List<AicraftInfoAndNumberOfTimesRegisteredDto>().ToList();

                transaction.Commit();
                return results;
            }
        }

        public List<AicraftInfoAndDateOfRegistrationDto> GetAicraftInfoAndDateOfPenultimateRegistrationDtos(int years)
        {
            using (ITransaction transaction = session.BeginTransaction())
            {
                List<AicraftInfoAndDateOfRegistrationDto> results = null;
                Aircraft aircraftAlias = null;
                AircraftRegistry aircraftRegistryAlias = null;
                AicraftInfoAndDateOfRegistrationDto DTO = null;


                var dt = DateTime.Now.AddYears(-years);
                results = session.QueryOver<Aircraft>(() => aircraftAlias)
                    .WithSubquery
                    .WhereValue(dt).Ge(QueryOver.Of<AircraftRegistry>(() => aircraftRegistryAlias)
                                  .Where(ar => aircraftRegistryAlias.SerialNumber == aircraftAlias.SerialNumber)
                                  .Select(Projections.Property(() => aircraftRegistryAlias.RegistrationDate))
                                  .OrderBy(ar => aircraftRegistryAlias.RegistrationDate).Desc
                                      .Skip(1)
                                      .Take(1))
                    .SelectList(selectionList => selectionList
                        .SelectGroup(() => aircraftAlias.IsOperational).WithAlias(() => DTO.IsOperational)
                        .SelectGroup(() => aircraftAlias.SerialNumber).WithAlias(() => DTO.SerialNumber)
                        .SelectGroup(() => aircraftAlias.Vne).WithAlias(() => DTO.Vne)
                        .SelectGroup(() => aircraftAlias.Manufacturer).WithAlias(() => DTO.Manufacturer)
                        .SelectGroup(() => aircraftAlias.Model).WithAlias(() => DTO.Model)
                        .SelectGroup(() => aircraftAlias.MaxTakeoffWeight).WithAlias(() => DTO.MaxTakeoffWeight)
                        .SelectSubQuery(QueryOver.Of<AircraftRegistry>(() => aircraftRegistryAlias)
                            .Where(() => aircraftRegistryAlias.SerialNumber == aircraftAlias.SerialNumber)
                            .SelectList(list => list
                                .Select(() => aircraftRegistryAlias.RegistrationDate))
                                .OrderBy(() => aircraftRegistryAlias.RegistrationDate).Desc
                                .Skip(1)
                                .Take(1)).WithAlias(() => DTO.RegistryDate))
                    .TransformUsing(Transformers.AliasToBean<AicraftInfoAndDateOfRegistrationDto>())
                    .List<AicraftInfoAndDateOfRegistrationDto>().ToList();


                //List<DateTime> temp =
                //    session.QueryOver<AircraftRegistry>()
                //        .Where(ar => ar.SerialNumber == "622")
                //        .Select(ar => ar.RegistrationDate)
                //        .List<DateTime>()
                //        .ToList();

                transaction.Commit();
                return results;
            }
        }

        public List<AicraftInfoAndDateOfRegistrationDto> GetAicraftInfoAndLastDateOfRegistrationDtos(int years)
        {
            using (ITransaction transaction = session.BeginTransaction())
            {
                List<AicraftInfoAndDateOfRegistrationDto> results = null;
                Aircraft aircraftAlias = null;
                AircraftRegistry aircraftRegistryAlias = null;
                AicraftInfoAndDateOfRegistrationDto DTO = null;


                var dt = DateTime.Now.AddYears(-years);
                results = session.QueryOver<Aircraft>(() => aircraftAlias)
                    .WithSubquery
                    .WhereValue(dt).Ge(QueryOver.Of<AircraftRegistry>(() => aircraftRegistryAlias)
                                  .Where(ar => aircraftRegistryAlias.SerialNumber == aircraftAlias.SerialNumber)
                                  .Select(Projections.Property(() => aircraftRegistryAlias.RegistrationDate))
                                  .OrderBy(ar => aircraftRegistryAlias.RegistrationDate).Desc
                                      .Take(1))
                    .SelectList(selectionList => selectionList
                        .SelectGroup(() => aircraftAlias.IsOperational).WithAlias(() => DTO.IsOperational)
                        .SelectGroup(() => aircraftAlias.SerialNumber).WithAlias(() => DTO.SerialNumber)
                        .SelectGroup(() => aircraftAlias.Vne).WithAlias(() => DTO.Vne)
                        .SelectGroup(() => aircraftAlias.Manufacturer).WithAlias(() => DTO.Manufacturer)
                        .SelectGroup(() => aircraftAlias.Model).WithAlias(() => DTO.Model)
                        .SelectGroup(() => aircraftAlias.MaxTakeoffWeight).WithAlias(() => DTO.MaxTakeoffWeight)
                        .SelectSubQuery(QueryOver.Of<AircraftRegistry>(() => aircraftRegistryAlias)
                            .Where(() => aircraftRegistryAlias.SerialNumber == aircraftAlias.SerialNumber)
                            .SelectList(list => list
                                .Select(() => aircraftRegistryAlias.RegistrationDate))
                                .OrderBy(() => aircraftRegistryAlias.RegistrationDate).Desc
                                .Take(1)).WithAlias(() => DTO.RegistryDate))
                    .TransformUsing(Transformers.AliasToBean<AicraftInfoAndDateOfRegistrationDto>())
                    .List<AicraftInfoAndDateOfRegistrationDto>().ToList();


                //List<DateTime> temp =
                //    session.QueryOver<AircraftRegistry>()
                //        .Where(ar => ar.SerialNumber == "622")
                //        .Select(ar => ar.RegistrationDate)
                //        .List<DateTime>()
                //        .ToList();

                transaction.Commit();
                return results;
            }
        }

        public List<AicraftInfoAndIfRegisteredBoolDto> GetAicraftInfoAndIfRegisteredBoolDto()
        {
            using (ITransaction transaction = session.BeginTransaction())
            {
                List<AicraftInfoAndIfRegisteredBoolDto> results = null;
                AicraftInfoAndIfRegisteredBoolDto DTO = null;
                AircraftRegistry aircraftRegistryAlias = null;
                Aircraft aircraftAlias = null;

                var projection = Projections.Conditional(
                            Subqueries.Gt(0, QueryOver.Of<AircraftRegistry>(() => aircraftRegistryAlias)
                                                .Where(ar => aircraftRegistryAlias.SerialNumber == aircraftAlias.SerialNumber)
                                                .SelectList(list => list
                                                    .SelectCount(() => aircraftRegistryAlias.SerialNumber)).DetachedCriteria) // this is the SUB-SELECT
                            , Projections.Constant(true, NHibernateUtil.Boolean)
                            , Projections.Constant(false, NHibernateUtil.Boolean)
                            );


                results = session.QueryOver<Aircraft>(() => aircraftAlias)
                    .WithSubquery
                    .WhereExists(QueryOver.Of<AircraftRegistry>(() => aircraftRegistryAlias)
                        .Where(ar => aircraftRegistryAlias.SerialNumber == aircraftAlias.SerialNumber)
                        .Select(Projections.Property(() => aircraftRegistryAlias.SerialNumber)))
                    .SelectList(selectionList => selectionList
                        .Select(() => aircraftAlias.IsOperational).WithAlias(() => DTO.IsOperational)
                        .Select(() => aircraftAlias.SerialNumber).WithAlias(() => DTO.SerialNumber)
                        .Select(() => aircraftAlias.Vne).WithAlias(() => DTO.Vne)
                        .Select(() => aircraftAlias.Manufacturer).WithAlias(() => DTO.Manufacturer)
                        .Select(() => aircraftAlias.Model).WithAlias(() => DTO.Model)
                        .Select(() => aircraftAlias.MaxTakeoffWeight).WithAlias(() => DTO.MaxTakeoffWeight)
                        .Select(() => true).WithAlias(() => DTO.IsRegistered))
                    .TransformUsing(Transformers.AliasToBean<AicraftInfoAndIfRegisteredBoolDto>())
                    .List<AicraftInfoAndIfRegisteredBoolDto>().ToList();

                results.AddRange(session.QueryOver<Aircraft>(() => aircraftAlias)
                    .WithSubquery
                    .WhereNotExists(QueryOver.Of<AircraftRegistry>(() => aircraftRegistryAlias)
                        .Where(ar => aircraftRegistryAlias.SerialNumber == aircraftAlias.SerialNumber)
                        .Select(Projections.Property(() => aircraftRegistryAlias.SerialNumber)))
                    .SelectList(selectionList => selectionList
                        .Select(() => aircraftAlias.IsOperational).WithAlias(() => DTO.IsOperational)
                        .Select(() => aircraftAlias.SerialNumber).WithAlias(() => DTO.SerialNumber)
                        .Select(() => aircraftAlias.Vne).WithAlias(() => DTO.Vne)
                        .Select(() => aircraftAlias.Manufacturer).WithAlias(() => DTO.Manufacturer)
                        .Select(() => aircraftAlias.Model).WithAlias(() => DTO.Model)
                        .Select(() => aircraftAlias.MaxTakeoffWeight).WithAlias(() => DTO.MaxTakeoffWeight)
                        .Select(() => false).WithAlias(() => DTO.IsRegistered))
                    .TransformUsing(Transformers.AliasToBean<AicraftInfoAndIfRegisteredBoolDto>())
                    .List<AicraftInfoAndIfRegisteredBoolDto>().ToList());



                transaction.Commit();
                return results;
            }
        }

        public List<string> GetAircraftRegisteredInTwoSpecificYears(int yearOne, int yearTwo)
        {
            using (ITransaction transaction = session.BeginTransaction())
            {
                List<string> results = null;
                Aircraft aircraftAlias = null;
                AircraftRegistry aircraftRegistryAlias = null;


                //results = session.QueryOver<Aircraft>(() => aircraftAlias)
                //    .WithSubquery
                //    .WhereValue(yearOne).Eq(QueryOver.Of<AircraftRegistry>(() => aircraftRegistryAlias)
                //        .Where(ar => aircraftRegistryAlias.SerialNumber == aircraftAlias.SerialNumber)
                //        .Select(Projections.Property(() => aircraftRegistryAlias.RegistrationDate)))
                //    .SelectList(selectionList => selectionList
                //        .Select(() => aircraftAlias.IsOperational).WithAlias(() => DTO.IsOperational)
                //        .Select(() => aircraftAlias.SerialNumber).WithAlias(() => DTO.SerialNumber)
                //        .Select(() => aircraftAlias.Vne).WithAlias(() => DTO.Vne)
                //        .Select(() => aircraftAlias.Manufacturer).WithAlias(() => DTO.Manufacturer)
                //        .Select(() => aircraftAlias.Model).WithAlias(() => DTO.Model)
                //        .Select(() => aircraftAlias.MaxTakeoffWeight).WithAlias(() => DTO.MaxTakeoffWeight)
                //        .SelectSubQuery(QueryOver.Of<AircraftRegistry>(() => aircraftRegistryAlias)
                //            .Where(ar => aircraftRegistryAlias.SerialNumber == aircraftAlias.SerialNumber)
                //            .Select(Projections.Property(() => aircraftRegistryAlias.RegistrationDate)))
                //        .WithAlias(() => DTO.RegistryDate))
                //    .TransformUsing(Transformers.AliasToBean<AicraftInfoAndDateOfRegistrationDto>())
                //    .List<AicraftInfoAndDateOfRegistrationDto>().ToList();


                //results = session.QueryOver<Aircraft>(() => aircraftAlias)
                //    .SelectList(list => list
                //    .SelectGroup(() => aircraftAlias.SerialNumber))
                //    .Where()
                //    .List<string>().ToList();

                DetachedCriteria dCriteria = DetachedCriteria.For<AircraftRegistry>("aircraftRegistryAlias")
                    .SetProjection(Projections.Property("aircraftRegistryAlias.SerialNumber"))
                    .Add(new OrExpression(new BetweenExpression(Projections.Property(() => aircraftRegistryAlias.RegistrationDate), new DateTime(yearTwo, 1, 1), new DateTime(yearTwo, 12, 31)), 
                                          new BetweenExpression(Projections.Property(() => aircraftRegistryAlias.RegistrationDate), new DateTime(yearOne, 1, 1), new DateTime(yearOne, 12, 31))));

                var iCriteria = session.CreateCriteria<AircraftRegistry>()
                    .SetProjection(Projections.Property("aircraftRegistryAlias.SerialNumber"))
                    .Add(new OrExpression(new BetweenExpression(Projections.Property(() => aircraftRegistryAlias.RegistrationDate), new DateTime(yearTwo, 1, 1), new DateTime(yearTwo, 12, 31)),
                                          new BetweenExpression(Projections.Property(() => aircraftRegistryAlias.RegistrationDate), new DateTime(yearOne, 1, 1), new DateTime(yearOne, 12, 31))));




                //results = session.QueryOver<Aircraft>(() => aircraftAlias)
                //    .SelectList(selectionList => selectionList
                //        .Select(Projections.Conditional(Restrictions.Between(Projections.SubQuery(QueryOver.Of<AircraftRegistry>(() => aircraftRegistryAlias)
                //                                                                                .Where(ar => aircraftRegistryAlias.SerialNumber == aircraftAlias.SerialNumber)
                //                                                                                .Select(Projections.Property(() => aircraftRegistryAlias.RegistrationDate))),
                //                                                       new DateTime(yearOne, 1, 1),
                //                                                       new DateTime(yearOne, 12, 31)),
                //                                   Projections.Property(() => aircraftAlias.SerialNumber),
                //                                   Projections.Constant("nope"))))
                //    .List<string>().ToList();
                ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                //results = session.QueryOver<Aircraft>(() => aircraftAlias)
                //    .WithSubquery
                //    .WhereExists(QueryOver.Of<AircraftRegistry>(() => aircraftRegistryAlias)
                //                                    .Where(ar => aircraftRegistryAlias.SerialNumber == aircraftAlias.SerialNumber)
                //                                    .Where(new BetweenExpression(Projections.Property(() => aircraftRegistryAlias.RegistrationDate), new DateTime(yearOne, 1, 1), new DateTime(yearOne, 12, 31)))
                //                                    .Select(Projections.Property(() => aircraftRegistryAlias.SerialNumber)))
                //    .Select(Projections.Property(()=> aircraftAlias.SerialNumber))
                //    .List<string>().ToList();

                ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                //results = session.QueryOver<Aircraft>(() => aircraftAlias)
                //    .WithSubquery
                //    .WhereExists(QueryOver.Of<AircraftRegistry>(() => aircraftRegistryAlias)
                //                                    .Where(ar => aircraftRegistryAlias.SerialNumber == aircraftAlias.SerialNumber)
                //                                    .Where(new OrExpression(new BetweenExpression(Projections.Property(() => aircraftRegistryAlias.RegistrationDate), new DateTime(yearOne, 1, 1), new DateTime(yearOne, 12, 31)),
                //                                                            new BetweenExpression(Projections.Property(() => aircraftRegistryAlias.RegistrationDate), new DateTime(yearTwo, 1, 1), new DateTime(yearTwo, 12, 31))))
                //                                    .Select(Projections.Property(() => aircraftRegistryAlias.SerialNumber)))
                //    .Select(Projections.Property(() => aircraftAlias.SerialNumber))
                //    .List<string>().ToList();


                ////////////////////////////////////////////////////////////////////////////////////////////////////

                //Conjunction conj = new Conjunction();
                //conj.Add(
                //    Subqueries.WhereProperty<Aircraft>(x => x.SerialNumber)
                //        .Eq(Subqueries.WhereExists());


                //conj.Add(Subqueries.WhereProperty<Aircraft>(x => x.SerialNumber)
                //        .Eq(QueryOver.Of<AircraftRegistry>(() => aircraftRegistryAlias)
                //            .Where(new BetweenExpression(
                //                        Projections.Property(() => aircraftRegistryAlias.RegistrationDate),
                //                        new DateTime(yearOne, 1, 1), new DateTime(yearOne, 12, 31)))
                //                    .Select(Projections.Property(() => aircraftRegistryAlias.SerialNumber))));


                //results = session.QueryOver<Aircraft>(() => aircraftAlias)
                //    .Where(conj)
                //    .Select(Projections.Property(() => aircraftAlias.SerialNumber))
                //    .List<string>().ToList();



                results = session.QueryOver<Aircraft>(() => aircraftAlias)
                    .Where(new AndExpression(Subqueries.WhereExists(QueryOver.Of<AircraftRegistry>(() => aircraftRegistryAlias)
                                                    .Where(ar => aircraftRegistryAlias.SerialNumber == aircraftAlias.SerialNumber)
                                                    .Where(new BetweenExpression(Projections.Property(() => aircraftRegistryAlias.RegistrationDate), new DateTime(yearOne, 1, 1), new DateTime(yearOne, 12, 31)))
                                                    .Select(Projections.Property(() => aircraftRegistryAlias.SerialNumber))),
                                             Subqueries.WhereExists(QueryOver.Of<AircraftRegistry>(() => aircraftRegistryAlias)
                                                    .Where(ar => aircraftRegistryAlias.SerialNumber == aircraftAlias.SerialNumber)
                                                    .Where(new BetweenExpression(Projections.Property(() => aircraftRegistryAlias.RegistrationDate), new DateTime(yearTwo, 1, 1), new DateTime(yearTwo, 12, 31)))
                                                    .Select(Projections.Property(() => aircraftRegistryAlias.SerialNumber)))))
                    .Select(Projections.Property(() => aircraftAlias.SerialNumber))
                    .List<string>().ToList();




                transaction.Commit();
                return results;
            }
        }

        public List<AircraftRegistry> GetAllAircraftRegistries()
        {
            using (ITransaction transaction = session.BeginTransaction())
            {
                List<AircraftRegistry> results = session.QueryOver<AircraftRegistry>().List<AircraftRegistry>().ToList();

                transaction.Commit();
                return results;
            }
        }
        
        public void DeleteById(long id, string serialnumber, string registration, DateTime registrationdate, bool hascrashed)
        {
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.Delete(session.Load<AircraftRegistry>(id));

                transaction.Commit();
            }
        }
    }
}