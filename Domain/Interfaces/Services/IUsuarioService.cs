using Domain.Entities;

namespace Domain.Interfaces.Services
{
	public interface IUsuarioService : IService<Usuario>
	{
		public Usuario Login(Usuario input);
		public IQueryable<Usuario> GetAll();
	}
}
