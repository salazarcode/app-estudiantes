using Domain.Entities;
using Domain.Interfaces.Repositories;

namespace Repository.Repositories
{
	public class EstudianteRepository : AbstractRepository<Estudiante>, IEstudianteRepository
	{
		public EstudianteRepository(DatabaseContext dbContext) : base(dbContext)
		{
		}
	}
}
