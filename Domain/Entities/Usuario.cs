using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public partial class Usuario
{
	public int Id { get; set; }

	public string? Cedula { get; set; }

	public int RoleId { get; set; }

	public string? Clave { get; set; }

	public string? Nombre { get; set; }

	public string? Apellido { get; set; }

	public string? Correo { get; set; }

	public string? Telefono { get; set; }

	public string? Direccion { get; set; }

	public virtual Role Role { get; set; } = null!;
}
