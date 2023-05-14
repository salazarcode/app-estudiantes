using AutoMapper;
using Domain.Entities;
using CreateUsuarioVM = API.DTO.Requests.CreateUsuarioVM;
using UpdateUsuarioVM = API.DTO.Requests.UpdateUsuarioVM;

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
