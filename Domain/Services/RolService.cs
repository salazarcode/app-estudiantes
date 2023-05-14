using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Interfaces.Tools;

namespace Domain.Services
{
	public class RolService : IRolService
	{
		private readonly IRolRepository _repo;
		public RolService(IRolRepository repo)
		{
			_repo = repo;
		}

		public IEnumerable<Rol> Get(int? id = null)
		{
			var res = new List<Rol>();

			if (id == null)
				res = _repo.Get().ToList();
			else
				res = new List<Rol>() { _repo.Get().First(x => x.Id == (int)id) };

			return res;
		}

		public Rol Add(Rol entity)
		{
			return _repo.Add(entity);
		}

		public Rol Update(Rol entity)
		{
			var rol = _repo.Get().FirstOrDefault(x => x.Id == (int)entity.Id);

			rol.Nombre = entity.Nombre;

			return _repo.Update(rol);
		}

		public void Remove(Rol entity)
		{
			_repo.Remove(entity);
		}
	}
}
