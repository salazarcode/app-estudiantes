namespace Domain.Interfaces.Services
{
	public interface IService<TEntity> where TEntity : class
	{
		IEnumerable<TEntity> Get(int? id);
		TEntity Add(TEntity entity);
		TEntity Update(TEntity entity);
		void Remove(TEntity entity);
	}
}
