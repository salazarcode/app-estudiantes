namespace API.DTO.Requests.Tutor
{
    public class UpdateTutorDTO
	{
		public int Id { get; set; }
		public string? Titulo { get; set; }
		public DateTime FechaInicio { get; set; }
		public DateTime FechaFin { get; set; }
		public bool Estado { get; set; }
	}
}
