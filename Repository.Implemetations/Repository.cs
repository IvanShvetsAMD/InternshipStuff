using System;
using Domain;
using NHibernate;
using NHibernate.SqlCommand;
using Repository.Interfaces;

namespace Repository.Implemetations
{
    internal abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        protected readonly ISession _session = SessionGenerator.Instance.GetSession();

        public void Save(TEntity entity)
        {
            using (ITransaction transaction = _session.BeginTransaction())
            {
                _session.SaveOrUpdate(entity);

                transaction.Commit();
            }
        }

        public TEntity LoadEntity<TEntity>(long ID) where TEntity : Entity
        {
            TEntity entity;
            using (ITransaction transaction = _session.BeginTransaction())
            {
                entity = _session.Load<TEntity>(ID);

                transaction.Commit();

                return entity;
            }
        }
    }
}