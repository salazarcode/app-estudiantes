using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Interfaces.Tools;

namespace Domain.Services
{
	public class TutorService : ITutorService
	{
		private readonly ITutorRepository _repo;
		public TutorService(ITutorRepository repo)
		{
			_repo = repo;
		}

		public IEnumerable<Tutor> Get(int? id = null)
		{
			var res = new List<Tutor>();

			if (id == null)
				res = _repo.Get().ToList();
			else
				res = new List<Tutor>() { _repo.Get().First(x => x.Id == (int)id) };

			return res;
		}

		public Tutor Add(Tutor entity)
		{
			return _repo.Add(entity);
		}

		public Tutor Update(Tutor entity)
		{
			var rol = _repo.Get().FirstOrDefault(x => x.Id == (int)entity.Id);

			//rol.Nombre = entity.Nombre;

			return _repo.Update(rol);
		}

		public void Remove(Tutor entity)
		{
			_repo.Remove(entity);
		}
	}
}
