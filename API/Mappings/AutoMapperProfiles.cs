using API.DTO.Requests;
using AutoMapper;
using Domain.Entities;

namespace API.Mappings
{
	public class AutoMapperProfiles : Profile
	{
		public AutoMapperProfiles()
		{
			CreateMap<UpdateUsuarioVM, Usuario>().ReverseMap();
			CreateMap<CreateUsuarioVM, Usuario>().ReverseMap();
		}
	}
}
