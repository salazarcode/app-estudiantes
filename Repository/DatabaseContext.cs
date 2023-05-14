﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
	public class DatabaseContext : DbContext
	{
		public DbSet<Usuario> Usuarios { get; set; }
		public DbSet<Administrador> Administrador { get; set; }
		public DbSet<Rol> Roles { get; set; }
		public DbSet<Tutor> Tutores { get; set; }
		public DbSet<Estudiante> Estudiantes { get; set; }
		public DbSet<Carrera> Carreras { get; set; }
		public DbSet<Servicio> Servicios { get; set; }

		public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
		{
		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Administrador>()
				.HasOne(a => a.Usuario)
				.WithMany()
				.HasForeignKey(a => a.UsuarioID);
		}
	}
}
