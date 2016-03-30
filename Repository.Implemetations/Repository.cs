using Domain;
using NHibernate;
using Repository.Interfaces;

namespace Repository.Implemetations
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        protected ISession session = SessionGenerator.Instance.GetSession();

        //protected IStatelessSession _session2 = SessionGenerator.Instance.GetStatelessSession;

        //protected SessionSingleton SesssionSingletonSession = SessionSingleton.GetSessionSingleton();

        //public Repository()
        //{
        //    _session = SesssionSingletonSession.GetSession;
        //}

        public void Save(TEntity entity)
        {
            //using (var session = SessionGenerator.Instance.GetSession())
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
            
            //using (var session = SessionGenerator.Instance.GetSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    entity = session.Load<TEntity>(ID);
                    transaction.Commit();

                    return entity;
                }
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