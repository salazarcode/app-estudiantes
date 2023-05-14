using Domain.Entities;

namespace Domain.Interfaces.Services
{
	public interface IUsuarioService : IService<Usuario>
	{
		public string Login(Usuario input);
	}
}
