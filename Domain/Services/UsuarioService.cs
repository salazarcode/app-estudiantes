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

			if (id != null)
				return res = new List<Usuario>() { _repo.GetWithRole().First(x => x.Id == (int)id) };


			return new List<Usuario>() { 
				_repo.GetWithRole().First(x => x.Id == (int)id) 
			};
		}

		public Usuario Update(Usuario entity)
		{
			var usuario = _repo.Get().FirstOrDefault(x => x.Id == (int)entity.Id);

			usuario.Cedula = entity.Cedula;
			usuario.Clave = _hasher.Hash(entity.Clave);
			usuario.RoleId = entity.RoleId;
			usuario.Nombre = entity.Nombre;
			usuario.Apellido = entity.Apellido;
			usuario.Telefono = entity.Telefono;
			usuario.Correo = entity.Correo;
			usuario.Direccion = entity.Direccion;

			return _repo.Update(usuario);
		}

		public void Remove(Usuario entity)
		{
			_repo.Remove(entity);
		}
		public Usuario Add(Usuario entity)
		{
			entity.Clave = _hasher.Hash(entity.Clave);

			return _repo.Add(entity);
		}

		public Usuario Login(Usuario input)
		{
			var usuario = _repo.GetWithRole().FirstOrDefault(x => x.Cedula == input.Cedula && x.Clave == _hasher.Hash(input.Clave));

			if (usuario == null)
				throw new Exception("Clave erronea");

			return usuario;
		}
	}
}
