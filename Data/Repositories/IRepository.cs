using System.Linq;

namespace FileBasket.Data.Repositories
{
    public interface IRepository<T> where T : class, IEntity
    {
        T GetById(int id);

        IQueryable<T> GetAll();

        void InsertOrUpdate(T entity);

        void Delete(T entity);
    }
}