namespace API.DTO.Requests.Estudiante
{
    public class CreateEstudianteDTO
	{
		public int? UserId { get; set; }
		public int? ServicioId { get; set; }
		public int? TutorId { get; set; }
		public int? CarreraId { get; set; }
	}
}
