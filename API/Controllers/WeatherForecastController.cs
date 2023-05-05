using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Repository.Abstract;
using Repository.Repositories;

namespace API.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class WeatherForecastController : ControllerBase
	{
		private static readonly string[] Summaries = new[]
		{
	   "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

		private readonly ILogger<WeatherForecastController> _logger;
		private readonly IUsuarioRepository _usuariosRepo;
		private readonly IAdministradorRepository _administradorRepo;

		public WeatherForecastController(ILogger<WeatherForecastController> logger, IUsuarioRepository usuariosRepo, IAdministradorRepository administradorRepo)
		{
			_logger = logger;
			_usuariosRepo	= usuariosRepo;
			_administradorRepo = administradorRepo;
		}

		[HttpGet]
		[Route("Usuarios")]
		public IEnumerable<Usuario> GetUsuarios()
		{
			var usuarios = _usuariosRepo.GetAll();
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