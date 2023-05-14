namespace API.DTO.Requests.Servicio
{
	public class CreateServicioDTO
	{
		public string? Titulo { get; set; }
		public DateTime FechaInicio { get; set; }
		public DateTime FechaFin { get; set; }
		public bool Estado { get; set; }
	}
}
