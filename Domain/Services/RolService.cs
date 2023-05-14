using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Interfaces.Tools;

namespace Domain.Services
{
	public class RoleService : IRoleService
	{
		private readonly IRoleRepository _repo;
		public RoleService(IRoleRepository repo)
		{
			_repo = repo;
		}

		public IEnumerable<Role> Get(int? id = null)
		{
			var res = new List<Role>();

			if (id == null)
				res = _repo.Get().ToList();
			else
				res = new List<Role>() { _repo.Get().First(x => x.Id == (int)id) };

			return res;
		}

		public Role Add(Role entity)
		{
			return _repo.Add(entity);
		}

		public Role Update(Role entity)
		{
			var rol = _repo.Get().FirstOrDefault(x => x.Id == (int)entity.Id);

			rol.Nombre = entity.Nombre;

			return _repo.Update(rol);
		}

		public void Remove(Role entity)
		{
			_repo.Remove(entity);
		}
	}
}
