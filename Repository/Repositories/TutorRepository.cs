using Domain.Entities;
using Domain.Interfaces.Repositories;

namespace Repository.Repositories
{
	public class TutorRepository : AbstractRepository<Tutor>, ITutorRepository
	{
		public TutorRepository(DatabaseContext dbContext) : base(dbContext)
		{
		}
	}
}