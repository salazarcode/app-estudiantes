using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Abstract
{
	public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class
	{
		protected readonly DatabaseContext DbContext;

		public BaseRepository(DatabaseContext dbContext)
		{
			DbContext = dbContext;
		}

		public TEntity GetById(int id)
		{
			return DbContext.Set<TEntity>().Find(id);
		}

		public IEnumerable<TEntity> GetAll()
		{
			return DbContext.Set<TEntity>().ToList();
		}

		public void Add(TEntity entity)
		{
			DbContext.Set<TEntity>().Add(entity);
			DbContext.SaveChanges();
		}

		public void Update(TEntity entity)
		{
			DbContext.Entry(entity).State = EntityState.Modified;
			DbContext.SaveChanges();
		}

		public void Remove(TEntity entity)
		{
			DbContext.Set<TEntity>().Remove(entity);
			DbContext.SaveChanges();
		}
	}
}
