using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Interfaces.Tools;

namespace Domain.Services
{
	public class EstudianteService : IEstudianteService
	{
		private readonly IEstudianteRepository _repo;
		public EstudianteService(IEstudianteRepository repo)
		{
			_repo = repo;
		}

		public IEnumerable<Estudiante> Get(int? id = null)
		{
			var res = new List<Estudiante>();

			if (id == null)
				res = _repo.Get().ToList();
			else
				res = new List<Estudiante>() { _repo.Get().First(x => x.Id == (int)id) };

			return res;
		}

		public Estudiante Add(Estudiante entity)
		{
			return _repo.Add(entity);
		}

		public Estudiante Update(Estudiante entity)
		{
			var estudiante = _repo.Get().FirstOrDefault(x => x.Id == (int)entity.Id);

			estudiante.Nombre = entity.Nombre;

			return _repo.Update(estudiante);
		}

		public void Remove(Estudiante entity)
		{
			_repo.Remove(entity);
		}
	}
}
