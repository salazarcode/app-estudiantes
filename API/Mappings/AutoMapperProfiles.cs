using AutoMapper;
using Domain.Entities;
using API.DTO.Requests.Usuario;
using API.DTO.Requests.Carrera;
using API.DTO.Requests.Role;
using API.DTO.Requests.Tutor;
using API.DTO.Requests.Servicio;
using API.DTO.Requests.Estudiante;

namespace API.Mappings
{
    public class AutoMapperProfiles : Profile
	{
		public AutoMapperProfiles()
		{
			CreateMap<UpdateUsuarioDTO, Usuario>().ReverseMap();
			CreateMap<CreateUsuarioDTO, Usuario>().ReverseMap();

			CreateMap<UpdateCarreraDTO, Carrera>().ReverseMap();
			CreateMap<CreateCarreraDTO, Carrera>().ReverseMap();

			CreateMap<UpdateRoleDTO, Role>().ReverseMap();
			CreateMap<CreateRoleDTO, Role>().ReverseMap();

			CreateMap<UpdateTutorDTO, Tutor>().ReverseMap();
			CreateMap<CreateTutorDTO, Tutor>().ReverseMap();

			CreateMap<UpdateServicioDTO, Servicio>().ReverseMap();
			CreateMap<CreateServicioDTO, Servicio>().ReverseMap();

			CreateMap<UpdateEstudianteDTO, Estudiante>().ReverseMap();
			CreateMap<CreateEstudianteDTO, Estudiante>().ReverseMap();
		}
	}
}
