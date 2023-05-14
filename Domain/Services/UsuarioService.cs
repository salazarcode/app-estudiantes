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
				res = _repo.GetWithRole().ToList();
			else
				res = new List<Usuario>() { _repo.GetWithRole().First(x => x.Id == (int)id) };

			return res;
		}

		public Usuario Add(Usuario entity)
		{
			entity.Clave = _hasher.Hash(entity.Clave);

			return _repo.Add(entity);
		}

		public Usuario Update(Usuario entity)
		{
			var usuario = _repo.Get().FirstOrDefault(x => x.Id == (int)entity.Id);

			usuario.Cedula = entity.Cedula;
			usuario.Clave = _hasher.Hash(entity.Clave);
			usuario.RoleId = entity.RoleId;	

			return _repo.Update(usuario);
		}

		public void Remove(Usuario entity)
		{
			_repo.Remove(entity);
		}

		public string Login(Usuario input)
		{
			var usuario = _repo.Get().FirstOrDefault(x => x.Cedula == input.Cedula);

			if (usuario != null)
			{
				var ClaveInput = _hasher.Hash(input.Clave);
				if (ClaveInput == usuario.Clave)
					return usuario.Clave;
				else
					throw new Exception("Clave erronea");

			}
			else
				throw new Exception("El usuario no existe");

		}
	}
}
