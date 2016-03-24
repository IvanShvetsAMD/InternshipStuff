﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using NHibernate;
using Repository.Interfaces;

namespace Repository.Implemetations
{
    internal class GeneratorRepository : IGeneratorRepository
    {
        public void Save(Generator entity)
        {
            using (ITransaction transaction = _session.BeginTransaction())
            {
                _session.SaveOrUpdate(entity);

                transaction.Commit();
            }
        }

        protected readonly ISession _session = SessionGenerator.Instance.GetSession();
    }
}