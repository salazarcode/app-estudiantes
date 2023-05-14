using Domain.Entities;
using Domain.Interfaces.Repositories;

namespace Repository.Repositories
{
	public class RoleRepository : AbstractRepository<Role>, IRoleRepository
	{
		public RoleRepository(DatabaseContext dbContext) : base(dbContext)
		{
		}
	}
}