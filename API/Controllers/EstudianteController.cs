using API.AuthFilter;
using API.DTO.Requests;
using API.DTO.Requests.Estudiante;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class EstudianteController : ControllerBase
	{
		private readonly IEstudianteService _estudiantesService;
		private readonly IMapper _mapper;

		public EstudianteController(IEstudianteService estudiantesService, IMapper mapper)
		{
			_estudiantesService = estudiantesService;
			_mapper = mapper;
		}

		[HttpGet]
		public IEnumerable<Estudiante> Get(int? id = null)
		{
			var res = _estudiantesService.Get(id != null ? (int)id : null);
			return res;
		}


		[HttpPut]
		[AuthenticationFilter("administrador")]
		public IActionResult Update([FromBody] UpdateEstudianteDTO input)
		{
			var estudiante = _mapper.Map<Estudiante>(input);
			var res = _estudiantesService.Update(estudiante);
			return Ok(res);
		}


		[HttpPost]
		[AuthenticationFilter("administrador")]
		public IActionResult Create([FromBody] CreateEstudianteDTO input)
		{
			var estudiante = _mapper.Map<Estudiante>(input);
			var res = _estudiantesService.Add(estudiante);
			return Ok(res);
		}

		[HttpDelete]
		[Route("{id}")]
		[AuthenticationFilter("administrador")]
		public IActionResult Delete([FromRoute] int id)
		{
			_estudiantesService.Remove(new Estudiante { Id = id });
			return Ok();
		}
	}
}