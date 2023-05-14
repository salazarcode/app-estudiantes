using Domain.Entities;

namespace Domain.Interfaces.Repositories
{
	public interface IUsuarioRepository : IRepository<Usuario>
	{
		public IEnumerable<Usuario> GetWithRole();
	}
}
