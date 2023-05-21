namespace API.DTO.Requests.Usuario
{
	public class CreateUsuarioDTO
	{
		public string? Cedula { get; set; }

		public string? Clave { get; set; }

		public string? Nombre { get; set; }

		public string? Apellido { get; set; }

		public string? Correo { get; set; }

		public string? Telefono { get; set; }

		public string? Direccion { get; set; }

		public int? CarreraID { get; set; }

		public int? TutorID { get; set; }
		public string? ServicioTitulo { get; set; }
		public DateTime ServicioInicio { get; set; }

	}
}
