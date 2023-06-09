using API.DTO.Requests.Usuario;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces.Services;
using Domain.Interfaces.Tools;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
	[ApiController]
	[Route("[controller]")]
	//	[AuthenticationFilter("administrador")]
	public class UsuarioController : ControllerBase
	{
		private readonly IUsuarioService _usuariosService;
		private readonly IEstudianteService _estudianteService;
		private readonly IServicioService _servicioService;
		private readonly IHasher	_hasher;
		private readonly IMapper _mapper;

		public UsuarioController(IUsuarioService usuariosService, IMapper mapper, IEstudianteService estudianteService, IServicioService servicioService, IHasher hasher)
		{
			_usuariosService = usuariosService;
			_mapper = mapper;
			_estudianteService = estudianteService;
			_servicioService = servicioService;
			_hasher = hasher;
		}

		[HttpGet]
		public IEnumerable<Usuario> Get(int? id = null)
		{
			var res = _usuariosService.Get(id != null ? (int)id : null);
			return res;
		}


		[HttpPut]
		[Route("{id}")]
		public IActionResult Update([FromRoute] int id, [FromBody] UpdateUsuarioDTO input)
		{
			var usuario = _usuariosService.Get(id).FirstOrDefault();

			if (usuario == null)
				return BadRequest("Usuario no encontrado");

			usuario.Nombre = input.Nombre ?? usuario.Nombre;
			usuario.Apellido = input.Apellido ?? usuario.Apellido;
			usuario.Cedula = input.Cedula ?? usuario.Cedula;

			if (input.Clave != null)
				usuario.Clave = _hasher.Hash(input.Clave);

			usuario.RoleId = input.RoleId ?? usuario.RoleId;
			usuario.Direccion	= input.Direccion ?? usuario.Direccion;
			usuario.Telefono	= input.Telefono ?? usuario.Telefono;
			usuario.Correo		= input.Correo ?? usuario.Correo;

			var res = _usuariosService.Update(usuario);
			return Ok(res);
		}

		[HttpDelete]
		[Route("{id}")]
		public IActionResult Delete([FromRoute] int id)
		{
			var usuario = _usuariosService.Get(id).FirstOrDefault();

			if (usuario == null)
				return BadRequest("Usuario no encontrado");

			if (usuario.Role.Nombre.ToLower() == "estudiante")
			{
				var estudiante = _estudianteService.GetAll().FirstOrDefault(x => x.UserId == usuario.Id);

				if (estudiante != null)
				{
					var servicio = _servicioService.GetAll().FirstOrDefault(x => x.Id == estudiante.ServicioId);
					_servicioService.Remove(servicio);

					_estudianteService.Remove(estudiante);
				}
			}

			_usuariosService.Remove(usuario);
			return Ok();
		}
	}
}