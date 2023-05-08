using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Services;
using Microsoft.AspNetCore.Mvc;
using Repository.Repositories;

namespace API.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class WeatherForecastController : ControllerBase
	{
		private readonly IUsuarioService _usuariosService;
		private readonly IAdministradorRepository _administradorRepo;

		public WeatherForecastController(IUsuarioService usuariosService, IAdministradorRepository administradorRepo)
		{
			_usuariosService = usuariosService;
			_administradorRepo = administradorRepo;
		}

		[HttpGet]
		[Route("Usuarios")]
		public IEnumerable<Usuario> GetUsuarios()
		{
			var usuarios = _usuariosService.GetAll();
			return usuarios;
		}

		[HttpGet]
		[Route("Admnistradores")]
		public IEnumerable<Administrador> GetAdministradores()
		{
			var administradores = _administradorRepo.GetAllWithUser();
			return administradores;
		}
	}
}