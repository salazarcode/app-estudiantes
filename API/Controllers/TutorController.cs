using API.AuthFilter;
using API.DTO.Requests;
using API.DTO.Requests.Tutor;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class TutorController : ControllerBase
	{
		private readonly ITutorService _tutoresService;
		private readonly IMapper _mapper;

		public TutorController(ITutorService tutoresService, IMapper mapper)
		{
			_tutoresService = tutoresService;
			_mapper = mapper;
		}

		[HttpGet]
		public IEnumerable<Tutor> Get(int? id = null)
		{
			var res = _tutoresService.Get(id != null ? (int)id : null);
			return res;
		}


		[HttpPut]
		[AuthenticationFilter("administrador")]
		public IActionResult Update([FromBody] UpdateTutorDTO input)
		{
			var usuario = _mapper.Map<Tutor>(input);
			var res = _tutoresService.Update(usuario);
			return Ok(res);
		}


		[HttpPost]
		[AuthenticationFilter("administrador")]
		public IActionResult Create([FromBody] CreateTutorDTO input)
		{
			var usuario = _mapper.Map<Tutor>(input);
			var res = _tutoresService.Add(usuario);
			return Ok(res);
		}

		[HttpDelete]
		[AuthenticationFilter("administrador")]
		[Route("{id}")]
		public IActionResult Delete([FromRoute] int id)
		{
			_tutoresService.Remove(new Tutor { Id = id });
			return Ok();
		}
	}
}