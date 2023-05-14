using Domain.Entities;

namespace Domain.Interfaces.Repositories
{
	public interface IEstudianteRepository : IRepository<Estudiante>
	{
		public IQueryable<Estudiante> GetWithDetails();
	}
}