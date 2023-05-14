namespace Domain.Interfaces.Repositories
{
	public interface IRepository<TEntity> where TEntity : class
	{
		IQueryable<TEntity?> Get();
		TEntity Add(TEntity entity);
		TEntity Update(TEntity entity);
		void Remove(TEntity entity);
	}
}
