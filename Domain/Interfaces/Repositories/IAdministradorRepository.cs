using Domain.Entities;

namespace Domain.Interfaces.Repositories
{
	public interface IAdministradorRepository : IRepository<Administrador>
	{
		public IEnumerable<Administrador> GetAllWithUser();
	}
}
