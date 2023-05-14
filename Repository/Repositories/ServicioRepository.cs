using Domain.Entities;
using Domain.Interfaces.Repositories;

namespace Repository.Repositories
{
	public class ServicioRepository : AbstractRepository<Servicio>, IServicioRepository
	{
		public ServicioRepository(DatabaseContext dbContext) : base(dbContext)
		{
		}
	}
}