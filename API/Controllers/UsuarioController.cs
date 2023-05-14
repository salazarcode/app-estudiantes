using Domain.Entities;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using API.DTO.Requests.Usuario;

namespace API.Controllers
{
    [ApiController]
	[Route("[controller]")]
	public class UsuarioController : ControllerBase
	{
		private readonly IUsuarioService _usuariosService;
		private readonly IMapper _mapper;

		public UsuarioController(IUsuarioService usuariosService, IMapper mapper)
		{
			_usuariosService = usuariosService;
			_mapper = mapper;
		}

		[HttpGet]
		public IEnumerable<Usuario> Get(int? id = null)
		{
			var res = _usuariosService.Get(id != null ? (int)id : null);
			return res;
		}


		[HttpPut]
		public IActionResult Update([FromBody] UpdateUsuarioDTO input)
		{
			var usuario = _mapper.Map<Usuario>(input);
			var res = _usuariosService.Update(usuario);
			return Ok(res);
		}


		[HttpPost]
		[Route("Register")]
		public IActionResult Create([FromBody] CreateUsuarioDTO input)
		{
			var usuario = _mapper.Map<Usuario>(input);
			var res = _usuariosService.Add(usuario);
			return Ok(res);
		}

		[HttpPost]
		[Route("Login")]
		public IActionResult Login([FromBody] LoginDTO input)
		{
			try
			{
				return Ok(_usuariosService.Login(new Usuario { 
					Cedula = input.Cedula,
					Clave = input.Clave,
				}));
			}
			catch (Exception e)
			{
				return BadRequest(e.Message);
			}

		}

		[HttpDelete]
		[Route("{id}")]
		public IActionResult Delete([FromRoute] int id)
		{
			_usuariosService.Remove(new Usuario{ Id = id });
			return Ok();
		}
	}
}