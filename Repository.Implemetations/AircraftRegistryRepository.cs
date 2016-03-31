using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
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

        public List<AicraftInfoAndDateOfRegistrationDto> GetAicraftInfoAndDateOfRegistrationDtos()
        {
            using (ITransaction transaction = session.BeginTransaction())
            {
                List<AicraftInfoAndDateOfRegistrationDto> results = null;
                Aircraft aircraftAlias = null;
                AircraftRegistry aircraftRegistryAlias = null;
                AicraftInfoAndDateOfRegistrationDto DTO = null;


                //results = session.QueryOver<Aircraft>(() => aircraftAlias)
                //    .SelectList(selectionList => selectionList
                //        .SelectGroup(() => aircraftAlias.IsOperational).WithAlias(() => DTO.IsOperational)
                //        .SelectGroup(() => aircraftAlias.SerialNumber).WithAlias(() => DTO.SerialNumber)
                //        .SelectGroup(() => aircraftAlias.Vne).WithAlias(() => DTO.Vne)
                //        .SelectGroup(() => aircraftAlias.Manufacturer).WithAlias(() => DTO.Manufacturer)
                //        .SelectGroup(() => aircraftAlias.Model).WithAlias(() => DTO.Model)
                //        .SelectGroup(() => aircraftAlias.MaxTakeoffWeight).WithAlias(() => DTO.MaxTakeoffWeight)
                //        .SelectSubQuery(QueryOver.Of<AircraftRegistry>(() => aircraftRegistryAlias)
                //            .Where(() => aircraftRegistryAlias.SerialNumber == aircraftAlias.SerialNumber)
                //            .And(Restrictions.Le(Projections.Property(() => aircraftRegistryAlias.RegistrationDate), DateTime.Now.Subtract(new TimeSpan(365, 0, 0, 0))))
                //            .SelectList(list => list
                //                .Select(() => aircraftRegistryAlias.RegistrationDate))).WithAlias(() => DTO.SecondLatestRegistration))
                //    .TransformUsing(Transformers.AliasToBean<AicraftInfoAndDateOfRegistrationDto>())
                //    .List<AicraftInfoAndDateOfRegistrationDto>().ToList();


                results = session.QueryOver<Aircraft>(() => aircraftAlias)
                    .Where(() => QueryOver.Of<AircraftRegistry>(() => aircraftRegistryAlias)
                                    .Where(ar => aircraftRegistryAlias.SerialNumber == aircraftAlias.SerialNumber)
                                    .Select(Projections.Avg(Projections.Property(() => aircraftRegistryAlias.RegistrationDate)))
                                    .OrderBy(ar => aircraftRegistryAlias.RegistrationDate).Desc
                                        .Skip(1)
                                        .Take(1) < DateTime.Now.Year - 1)
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
                                .Take(1)).WithAlias(() => DTO.SecondLatestRegistration))
                    .TransformUsing(Transformers.AliasToBean<AicraftInfoAndDateOfRegistrationDto>())
                    .List<AicraftInfoAndDateOfRegistrationDto>().ToList();


                List<DateTime> temp =
                    session.QueryOver<AircraftRegistry>()
                        .Where(ar => ar.SerialNumber == "622")
                        .Select(ar => ar.RegistrationDate)
                        .List<DateTime>()
                        .ToList();

                transaction.Commit();
                return results;
            }
        }
    }
}