using Microsoft.EntityFrameworkCore;
using Domain.Interfaces.Repositories;

namespace Repository
{
    public abstract class AbstractRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DatabaseContext DbContext;

        protected AbstractRepository(DatabaseContext dbContext)
        {
            DbContext = dbContext;
        }

        public IQueryable<TEntity?> Get()
        {
	        return DbContext.Set<TEntity>();
        }

        public TEntity Add(TEntity entity)
        {
            DbContext.Set<TEntity>().Add(entity);
            DbContext.SaveChanges();
            return entity;
        }

        public TEntity Update(TEntity entity)
        {
            DbContext.Entry(entity).State = EntityState.Modified;
            DbContext.SaveChanges();
            return entity;
        }

        public void Remove(TEntity entity)
        {
            DbContext.Set<TEntity>().Remove(entity);
            DbContext.SaveChanges();
        }
    }
}
