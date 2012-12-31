using System.Data;
using System.Data.Entity;
using System.Linq;

namespace FileBasket.Data.Repositories.Impl
{
    public class GenericRepository<T> : IRepository<T> where T : class, IEntity
    {
        private readonly DbContext context;

        public GenericRepository(DbContext context)
        {
            this.context = context;
        }


        protected IDbSet<T> DbSet
        {
            get
            {
                return context.Set<T>();
            }
        }

        #region IRepository<T> Members

        public T GetById(int id)
        {
            return DbSet.Find(id);
        }

        public IQueryable<T> GetAll()
        {
            return DbSet;
        }

        public void InsertOrUpdate(T entity)
        {
            if (IsNew(entity))
            {
                DbSet.Add(entity);
            }
            else
            {
                AttachForUpdate(entity);
            }
        }

        public void Delete(T entity)
        {
            DbSet.Attach(entity);
            context.Entry(entity).State = EntityState.Deleted;
            DbSet.Remove(entity);
        }

        #endregion

        protected virtual bool IsNew(IEntity entity)
        {
            return entity.Id == 0;
        }

        protected void AttachForUpdate(T entity)
        {
            if (IsNew(entity))
            {
                return;
            }

            if (!IsAttached(entity))
            {
                DbSet.Attach(entity);
            }
        }

        protected bool IsAttached(T entity)
        {
            return DbSet.Local.Contains(entity);
        }
    }
}