using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Interfaces.Tools;

namespace Domain.Services
{
	public class ServicioService : IServicioService
	{
		private readonly IServicioRepository _repo;
		public ServicioService(IServicioRepository repo)
		{
			_repo = repo;
		}

		public IEnumerable<Servicio> Get(int? id = null)
		{
			var res = new List<Servicio>();

			if (id == null)
				res = _repo.Get().ToList();
			else
				res = new List<Servicio>() { _repo.Get().First(x => x.Id == (int)id) };

			return res;
		}

		public Servicio Add(Servicio entity)
		{
			return _repo.Add(entity);
		}

		public Servicio Update(Servicio entity)
		{
			var servicio = _repo.Get().FirstOrDefault(x => x.Id == (int)entity.Id);

			///servicio.Nombre = entity.Nombre;

			return _repo.Update(servicio);
		}

		public void Remove(Servicio entity)
		{
			_repo.Remove(entity);
		}
	}
}
