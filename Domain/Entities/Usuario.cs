using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Domain.Entities
{
	[Table("usuario")]
	public class Usuario
	{
		[Column("id")]
		public int id { get; set; }

		[Column("cedula")]
		public string cedula { get; set; }

		[Column("rolid")]
		public int rolid { get; set; }

		[Column("clave")]
		public string clave { get; set; }
		//[column("nombredelacolumna")]
		//public administrador administrador { get; set; }
		//[column("nombredelacolumna")]
		//public estudiante estudiante { get; set; }
		//[column("nombredelacolumna")]
		//public rol rol { get; set; }
	}
}
