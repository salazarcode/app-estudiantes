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
		public IActionResult Update([FromBody] UpdateServicioDTO input)
		{
			var usuario = _mapper.Map<Servicio>(input);
			var res = _serviciosService.Update(usuario);
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