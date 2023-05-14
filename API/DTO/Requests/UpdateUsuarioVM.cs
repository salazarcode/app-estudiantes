namespace API.DTO.Requests
{
	public class UpdateUsuarioVM
	{
		public int? id { get; set; }
		public string? cedula { get; set; }
		public int? rolid { get; set; }
		public string? clave { get; set; }
	}
}
