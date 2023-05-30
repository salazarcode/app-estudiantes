using API.AuthFilter;
using API.DTO.Requests;
using API.DTO.Requests.Estudiante;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces.Services;
using Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class EstudianteController : ControllerBase
	{
		private readonly IUsuarioService _usuariosService;
		private readonly IEstudianteService _estudiantesService;
		private readonly IServicioService _servicioService;
		private readonly IMapper _mapper;

		//agrega las propiedades faltantes 
		public EstudianteController(IEstudianteService estudiantesService, IMapper mapper, IUsuarioService usuarioService,IServicioService servicioService)
		{
			_estudiantesService = estudiantesService;
			_mapper = mapper;
			_usuariosService = usuarioService;
			_servicioService = servicioService;

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
			var estudiante = _estudiantesService.Get(id).FirstOrDefault();
			
			if (estudiante == null)
				return BadRequest("Estudiante no encontrado");

			var usuario = _usuariosService.GetAll().FirstOrDefault(x => x.Id == estudiante.UserId);
			var servicio = _servicioService.GetAll().FirstOrDefault(x => x.Id == estudiante.ServicioId);

			if (usuario != null) 
				_usuariosService.Remove(usuario);

			if (servicio != null)
				_servicioService.Remove(servicio);

			if (estudiante != null)
				_estudiantesService.Remove(estudiante);

			return Ok();
		}
	}
}