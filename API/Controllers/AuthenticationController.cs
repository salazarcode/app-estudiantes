using API.DTO.Requests.Usuario;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces.Services;
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
		private readonly IEncrypter _encrypter;

		public AuthenticationController(IUsuarioService usuariosService, IEncrypter encrypter)
		{
			_usuariosService = usuariosService;
			_encrypter = encrypter;
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
	}
}
