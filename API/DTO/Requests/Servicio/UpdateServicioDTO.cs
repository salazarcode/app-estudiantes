namespace API.DTO.Requests.Servicio
{
	public class UpdateServicioDTO
	{
		public int? id { get; set; }
		public string? Titulo { get; set; }
		public DateTime FechaInicio { get; set; }
		public DateTime FechaFin { get; set; }
		public bool Estado { get; set; }
	}
}
