using Domain.Entities;
using Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Repository.Repositories
{
	public class EstudianteRepository : AbstractRepository<Estudiante>, IEstudianteRepository
	{
		public EstudianteRepository(DatabaseContext dbContext) : base(dbContext)
		{
		}

		public IQueryable<Estudiante> GetWithDetails()
		{
			return this.Get()
						.Include(x => x.User)
						.Include(x => x.Carrera)
						.Include(x => x.Servicio)
						.Include(x => x.Tutor);
		}
	}
}
