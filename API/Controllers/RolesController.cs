using API.DTO.Requests;
using API.DTO.Requests.Role;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class RolesController : ControllerBase
	{
		private readonly IRoleService _rolesService;
		private readonly IMapper _mapper;

		public RolesController(IRoleService rolesService, IMapper mapper)
		{
			_rolesService = rolesService;
			_mapper = mapper;
		}

		[HttpGet]
		public IEnumerable<Role> Get(int? id = null)
		{
			var res = _rolesService.Get(id != null ? (int)id : null);
			return res;
		}


		[HttpPut]
		public IActionResult Update([FromBody] UpdateRoleDTO input)
		{
			var usuario = _mapper.Map<Role>(input);
			var res = _rolesService.Update(usuario);
			return Ok(res);
		}


		[HttpPost]
		public IActionResult Create([FromBody] CreateRoleDTO input)
		{
			var usuario = _mapper.Map<Role>(input);
			var res = _rolesService.Add(usuario);
			return Ok(res);
		}

		[HttpDelete]
		[Route("{id}")]
		public IActionResult Delete([FromRoute] int id)
		{
			_rolesService.Remove(new Role { Id = id });
			return Ok();
		}
	}
}