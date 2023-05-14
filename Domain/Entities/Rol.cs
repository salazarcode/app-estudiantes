using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
	[Table("roles")]
	public class Rol
	{
		[Column("id")]
		public int Id { get; set; }

		[Column("nombre")]
		public string Nombre { get; set; }
    }
}
