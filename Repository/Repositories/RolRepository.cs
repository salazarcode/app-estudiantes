using Domain.Entities;
using Domain.Interfaces.Repositories;

namespace Repository.Repositories
{
	public class RolRepository : AbstractRepository<Rol>, IRolRepository
	{
		public RolRepository(DatabaseContext dbContext) : base(dbContext)
		{
		}
	}
}