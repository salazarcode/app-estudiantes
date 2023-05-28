using Domain.Entities;

namespace Domain.Interfaces.Services
{
	public interface IEstudianteService : IService<Estudiante>
	{
		public IQueryable<Estudiante> GetAll();
	}
}