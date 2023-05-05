using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
	[Table("administrador")]
	public class Administrador
	{
          [Column("id")]
		public int Id { get; set; }

		[Column("nombre")]
		public string? Nombre { get; set; }

		[Column("apellido")]
		public string? Apellido { get; set; }

		[Column("correo")]
		public string? Correo { get; set; }

		[Column("telefono")]
		public string? Telefono { get; set; }

		[Column("userid")]
		public int UsuarioID { get; set; }

		public virtual Usuario? Usuario { get; set; }
    }
}
