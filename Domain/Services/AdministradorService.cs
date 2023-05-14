using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Interfaces.Tools;

namespace Domain.Services
{
	public class AdministradorService : IAdministradorService
	{
		private readonly IAdministradorRepository _repo;
		public AdministradorService(IAdministradorRepository repo)
		{
			_repo = repo;
		}

		public IEnumerable<Administrador> Get(int? id = null)
		{
			var res = new List<Administrador>();

			if (id == null)
				res = _repo.Get().ToList();
			else
				res = new List<Administrador>() { _repo.Get().First(x => x.Id == (int)id) };

			return res;
		}

		public Administrador Add(Administrador entity)
		{
			return _repo.Add(entity);
		}

		public Administrador Update(Administrador entity)
		{
			var administrador = _repo.Get().FirstOrDefault(x => x.Id == (int)entity.Id);

			administrador.Nombre = entity.Nombre;

			return _repo.Update(administrador);
		}

		public void Remove(Administrador entity)
		{
			_repo.Remove(entity);
		}
	}
}
