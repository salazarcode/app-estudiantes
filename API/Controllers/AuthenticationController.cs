using API.DTO.Requests.Usuario;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces.Services;
using Domain.Services;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Cryptography;

namespace API.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class AuthenticationController : Controller
	{
		private readonly IUsuarioService _usuariosService;
		private readonly IServicioService _servicioService;
		private readonly IEstudianteService _estudianteService;
		private readonly IEncrypter _encrypter;
		private readonly IMapper _mapper;

		public AuthenticationController(IUsuarioService usuariosService, IEncrypter encrypter, IServicioService servicioService, IEstudianteService estudianteService, IMapper mapper)
		{
			_usuariosService = usuariosService;
			_encrypter = encrypter;
			_servicioService = servicioService;
			_estudianteService = estudianteService;
			_mapper = mapper;	
		}

		[HttpPost]
		[Route("Login")]
		public IActionResult Login([FromBody] LoginDTO input)
		{
			try
			{
				var usuario = _usuariosService.Login(new Usuario
				{
					Cedula = input.Cedula,
					Clave = input.Clave,
				});
				string usuarioEncrypted = JsonConvert.SerializeObject(usuario);
				usuarioEncrypted = _encrypter.Encrypt(usuarioEncrypted);

				return Ok(usuarioEncrypted);
			}
			catch (Exception e)
			{
				return BadRequest(e.Message);
			}
		}

		[HttpPost]
		[Route("Register")]
		public IActionResult Create([FromBody] CreateUsuarioDTO input)
		{
			Servicio servicio = new Servicio();
			servicio.Titulo = input.ServicioTitulo;
			servicio.FechaInicio = input.ServicioInicio;
			servicio.FechaFin = input.ServicioInicio.AddMonths(1);
			servicio.Estado = false;
			_servicioService.Add(servicio);

			Usuario usuario = _mapper.Map<Usuario>(input);
			usuario.RoleId = 2;
			_usuariosService.Add(usuario);

			Estudiante estudiante = new Estudiante();
			estudiante.UserId = usuario.Id;
			estudiante.TutorId = (int)input.TutorID;
			estudiante.ServicioId = servicio.Id;
			estudiante.CarreraId = (int)input.CarreraID;

			return Ok(_estudianteService.Get(estudiante.Id));
		}
	}
}
