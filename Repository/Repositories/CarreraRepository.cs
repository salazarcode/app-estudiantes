using Domain.Entities;
using Domain.Interfaces.Repositories;

namespace Repository.Repositories
{
	public class CarreraRepository : AbstractRepository<Carrera>, ICarreraRepository
	{
		public CarreraRepository(DatabaseContext dbContext) : base(dbContext)
		{
		}
	}
}