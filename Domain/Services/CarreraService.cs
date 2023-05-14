using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Interfaces.Tools;

namespace Domain.Services
{
	public class CarreraService : ICarreraService
	{
		private readonly ICarreraRepository _repo;
		public CarreraService(ICarreraRepository repo)
		{
			_repo = repo;
		}

		public IEnumerable<Carrera> Get(int? id = null)
		{
			var res = new List<Carrera>();

			if (id == null)
				res = _repo.Get().ToList();
			else
				res = new List<Carrera>() { _repo.Get().First(x => x.Id == (int)id) };

			return res;
		}

		public Carrera Add(Carrera entity)
		{
			return _repo.Add(entity);
		}

		public Carrera Update(Carrera entity)
		{
			var carrera = _repo.Get().FirstOrDefault(x => x.Id == (int)entity.Id);

			carrera.Descripcion = entity.Descripcion;

			return _repo.Update(carrera);
		}

		public void Remove(Carrera entity)
		{
			_repo.Remove(entity);
		}
	}
}
