using Domain;
using NHibernate;
using Repository.Interfaces;

namespace Repository.Implemetations
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        protected ISession session = SessionGenerator.Instance.GetSession();

        public void Save(TEntity entity)
        {
            {
                using (ITransaction transaction = session.BeginTransaction())
                {

                    session.SaveOrUpdate(entity);

                    transaction.Commit();
                }
            }
        }

        public TEntity LoadEntity<TEntity>(long ID) where TEntity : Entity
        {
            TEntity entity;
            using (ITransaction transaction = session.BeginTransaction())
            {
                entity = session.Load<TEntity>(ID);
                transaction.Commit();

                return entity;
            }

        }

        public void Delete(TEntity entity)
        {
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.Delete(entity);
                transaction.Commit();
            }
        }
    }
}