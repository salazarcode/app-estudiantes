namespace API.DTO.Requests.Usuario
{
    public class UpdateUsuarioDTO
    {
		public string? Cedula { get; set; }

		public int? RoleId { get; set; }

		public string? Clave { get; set; }

		public string? Nombre { get; set; }

		public string? Apellido { get; set; }

		public string? Correo { get; set; }

		public string? Telefono { get; set; }

		public string? Direccion { get; set; }
	}
}
