using System;
using Domain;
using NHibernate;
using Repository.Interfaces;

namespace Repository.Implemetations
{
    internal abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        public void Save(TEntity entity)
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