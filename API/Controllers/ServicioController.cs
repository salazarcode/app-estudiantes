using API.AuthFilter;
using API.DTO.Requests;
using API.DTO.Requests.Servicio;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
	[ApiController]
	[Route("[controller]")]
//	[AuthenticationFilter("administrador")]
	public class ServicioController : ControllerBase
	{
		private readonly IServicioService _serviciosService;
		private readonly IMapper _mapper;

		public ServicioController(IServicioService serviciosService, IMapper mapper)
		{
			_serviciosService = serviciosService;
			_mapper = mapper;
		}

		[HttpGet]
		public IEnumerable<Servicio> Get(int? id = null)
		{
			var res = _serviciosService.Get(id != null ? (int)id : null);
			return res;
		}


		[HttpPut]
		[Route("{id}")]
		public IActionResult Update([FromRoute] int id, [FromBody] UpdateServicioDTO input)
		{
			var servicio = _serviciosService.Get(id).FirstOrDefault();
			//valiadacion de null	
			if (servicio == null)
				return BadRequest("Servicio no encontrado");

			servicio.Titulo	= input.Titulo ?? servicio.Titulo;
			servicio.FechaFin	= input.FechaFin;
			servicio.FechaInicio	= input.FechaInicio;
			servicio.Estado	= input.Estado;

			var res = _serviciosService.Update(servicio);
			return Ok(res);
		}


		[HttpPost]
		public IActionResult Create([FromBody] CreateServicioDTO input)
		{
			var usuario = _mapper.Map<Servicio>(input);
			var res = _serviciosService.Add(usuario);
			return Ok(res);
		}

		[HttpDelete]
		[Route("{id}")]
		public IActionResult Delete([FromRoute] int id)
		{
			_serviciosService.Remove(new Servicio { Id = id });
			return Ok();
		}
	}
}