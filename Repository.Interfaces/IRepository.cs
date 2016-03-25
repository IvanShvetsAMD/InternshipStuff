using Domain;

namespace Repository.Interfaces
{
    public interface IRepository<TEntity> where TEntity : Entity
    {
        void Save(TEntity entity);
    }
}