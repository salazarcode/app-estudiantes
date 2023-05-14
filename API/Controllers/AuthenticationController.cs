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
		private readonly string _key;

		public AuthenticationController(IUsuarioService usuariosService, IEncrypter encrypter, IConfiguration conf)
		{
			_usuariosService = usuariosService;
			_encrypter = encrypter;
			_key	= conf["EncryptionKey"].ToString();
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
				usuarioEncrypted = _encrypter.Encrypt(usuarioEncrypted, _key);

				return Ok(usuarioEncrypted);
			}
			catch (Exception e)
			{
				return BadRequest(e.Message);
			}
		}

		[HttpGet]
		[Route("GenRandomKey")]
		public string GenRandomKey() {
			byte[] claveBytes = new byte[32]; // 32 bytes = 256 bits

			using (var rng = new RNGCryptoServiceProvider())
			{
				rng.GetBytes(claveBytes);
			}

			string clave = Convert.ToBase64String(claveBytes);
			return clave;
		}
	}
}
