using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Interfaces.Tools;

namespace Domain.Services
{
	public class UsuarioService : IUsuarioService
	{
		private readonly IHasher _hasher;
		private readonly IUsuarioRepository _repo;
		public UsuarioService(IUsuarioRepository repo, IHasher hasher)
		{
			_hasher = hasher;
			_repo = repo;
		}

		public IEnumerable<Usuario> Get(int? id = null)
		{
			var res = new List<Usuario>();

			if (id == null)
				res = _repo.GetWithRol().ToList();
			else
				res = new List<Usuario>() { _repo.GetWithRol().First(x => x.Id == (int)id) };

			return res;
		}

		public Usuario Add(Usuario entity)
		{
			entity.clave = _hasher.Hash(entity.clave);

			return _repo.Add(entity);
		}

		public Usuario Update(Usuario entity)
		{
			var usuario = _repo.Get().FirstOrDefault(x => x.Id == (int)entity.Id);

			usuario.cedula = entity.cedula;
			usuario.clave = _hasher.Hash(entity.clave);
			usuario.rolid = entity.rolid;	

			return _repo.Update(usuario);
		}

		public void Remove(Usuario entity)
		{
			_repo.Remove(entity);
		}
	}
}
