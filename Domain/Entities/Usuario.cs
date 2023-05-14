﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
	[Table("usuario")]
	public class Usuario
	{
		[Column("id")]
		public int? Id { get; set; }

		[Column("cedula")]
		public string? cedula { get; set; }

		[Column("rolid")]
		public int? rolid { get; set; }

		[Column("clave")]
		public string? clave { get; set; }

		public Rol Rol { get; set; }
	}
}
