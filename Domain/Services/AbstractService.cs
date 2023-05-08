using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;

namespace Domain.Services
{
    public abstract class AbstractService<TEntity> : IService<TEntity> where TEntity : class
    {
	   private readonly IRepository<TEntity> _repo;
        protected AbstractService(IRepository<TEntity> repo)
        {
             _repo = repo;
        }

        public TEntity? GetById(int id)
        {
             return _repo.GetById(id);
        }

        public IEnumerable<TEntity> GetAll()
		{
			return _repo.GetAll();
		}

        public void Add(TEntity entity)
        {
             _repo.Add(entity);
        }

        public void Update(TEntity entity)
        {
             _repo.Update(entity);
        }

        public void Remove(TEntity entity)
        {
             _repo.Remove(entity);
        }
    }
}
