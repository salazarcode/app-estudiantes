using API.AuthFilter;
using API.DTO.Requests.Usuario;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
	[ApiController]
	[Route("[controller]")]
//	[AuthenticationFilter("administrador")]
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

		[HttpDelete]
		[Route("{id}")]
		public IActionResult Delete([FromRoute] int id)
		{
			_usuariosService.Remove(new Usuario { Id = id });
			return Ok();
		}
	}
}