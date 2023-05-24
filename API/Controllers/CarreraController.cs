using API.AuthFilter;
using API.DTO.Requests.Carrera;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class CarreraController : ControllerBase
	{
		private readonly ICarreraService _carrerasService;
		private readonly IMapper _mapper;

		public CarreraController(ICarreraService carrerasService, IMapper mapper)
		{
			_carrerasService = carrerasService;
			_mapper = mapper;
		}

		[HttpGet]
		public IEnumerable<Carrera> Get(int? id = null)
		{
			var res = _carrerasService.Get(id != null ? (int)id : null);
			return res;
		}


		[HttpPut]
		[AuthenticationFilter("administrador")]
		public IActionResult Update([FromBody] UpdateCarreraDTO input)
		{
			var usuario = _mapper.Map<Carrera>(input);
			var res = _carrerasService.Update(usuario);
			return Ok(res);
		}


		[HttpPost]
		[AuthenticationFilter("administrador")]
		public IActionResult Create([FromBody] CreateCarreraDTO input)
		{
			var usuario = _mapper.Map<Carrera>(input);
			var res = _carrerasService.Add(usuario);
			return Ok(res);
		}

		[HttpDelete]
		[AuthenticationFilter("administrador")]
		[Route("{id}")]
		public IActionResult Delete([FromRoute] int id)
		{
			_carrerasService.Remove(new Carrera { Id = id });
			return Ok();
		}
	}
}