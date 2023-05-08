using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;

namespace Domain.Services
{
	public class UsuarioService : AbstractService<Usuario>, IUsuarioService
	{
		public UsuarioService(IUsuarioRepository repo) : base(repo)
		{
		}
	}
}
