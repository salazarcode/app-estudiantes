using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Repository;

public partial class DatabaseContext : DbContext
{

	public DatabaseContext(DbContextOptions<DatabaseContext> options)
	    : base(options)
	{
	}

	public virtual DbSet<Carrera> Carreras { get; set; }

	public virtual DbSet<Estudiante> Estudiantes { get; set; }

	public virtual DbSet<Role> Rolees { get; set; }

	public virtual DbSet<Servicio> Servicios { get; set; }

	public virtual DbSet<Tutor> Tutors { get; set; }

	public virtual DbSet<Usuario> Usuarios { get; set; }
	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<Carrera>(entity =>
		{
			entity.HasKey(e => e.Id).HasName("PK__carrera__82525F26D6A9BE3A");

			entity.ToTable("carrera");

			entity.Property(e => e.Id).HasColumnName("id");
			entity.Property(e => e.Descripcion)
			  .HasMaxLength(30)
			  .IsUnicode(false)
			  .HasColumnName("descripcion");
		});

		modelBuilder.Entity<Estudiante>(entity =>
		{
			entity.HasKey(e => e.Id).HasName("PK__estudian__3213E83F7B41AF5A");

			entity.ToTable("estudiantes");

			entity.HasIndex(e => e.UserId, "UQ__estudian__1788CCAD9C5F5A65").IsUnique();

			entity.Property(e => e.Id).HasColumnName("id");
			entity.Property(e => e.CarreraId).HasColumnName("CarreraID");
			entity.Property(e => e.ServicioId).HasColumnName("ServicioID");
			entity.Property(e => e.TutorId).HasColumnName("TutorID");
			entity.Property(e => e.UserId).HasColumnName("UserID");
		});

		modelBuilder.Entity<Role>(entity =>
		{
			entity.HasKey(e => e.Id).HasName("PK__roles__6ABCB5E0206BC93D");

			entity.ToTable("roles");

			entity.Property(e => e.Id).HasColumnName("id");
			entity.Property(e => e.Nombre)
			  .HasMaxLength(30)
			  .IsUnicode(false)
			  .HasColumnName("nombre");
		});

		modelBuilder.Entity<Servicio>(entity =>
		{
			entity.HasKey(e => e.Id).HasName("PK__servicio__6FD07FDC9F9075C1");

			entity.ToTable("servicio");

			entity.Property(e => e.Id).HasColumnName("id");
			entity.Property(e => e.Estado).HasColumnName("estado");
			entity.Property(e => e.FechaFin).HasColumnType("date");
			entity.Property(e => e.FechaInicio).HasColumnType("date");
			entity.Property(e => e.Titulo)
			  .HasMaxLength(40)
			  .IsUnicode(false)
			  .HasColumnName("titulo");
		});

		modelBuilder.Entity<Tutor>(entity =>
		{
			entity.HasKey(e => e.Id).HasName("PK__tutor__3213E83FE0494DB2");

			entity.ToTable("tutor");

			entity.Property(e => e.Id).HasColumnName("id");
			entity.Property(e => e.Apellido)
			  .HasMaxLength(40)
			  .IsUnicode(false)
			  .HasColumnName("apellido");
			entity.Property(e => e.Ci)
			  .HasMaxLength(8)
			  .HasColumnName("ci");
			entity.Property(e => e.Nombre)
			  .HasMaxLength(40)
			  .IsUnicode(false)
			  .HasColumnName("nombre");
			entity.Property(e => e.Telefono)
			  .HasMaxLength(11)
			  .HasColumnName("telefono");
		});

		modelBuilder.Entity<Usuario>(entity =>
		{
			entity.HasKey(e => e.Id).HasName("PK__usuario__4E3E04AD8AD72E3E");

			entity.ToTable("usuario");

			entity.Property(e => e.Id).HasColumnName("id");
			entity.Property(e => e.Apellido)
			  .HasMaxLength(40)
			  .HasColumnName("apellido");
			entity.Property(e => e.Cedula)
			  .HasMaxLength(8)
			  .IsUnicode(false)
			  .HasColumnName("cedula");
			entity.Property(e => e.Clave)
			  .HasMaxLength(64)
			  .HasColumnName("clave");
			entity.Property(e => e.Correo)
			  .HasMaxLength(30)
			  .HasColumnName("correo");
			entity.Property(e => e.Direccion)
			  .HasMaxLength(30)
			  .HasColumnName("direccion");
			entity.Property(e => e.Nombre)
			  .HasMaxLength(40)
			  .HasColumnName("nombre");
			entity.Property(e => e.RoleId).HasColumnName("RolID");
			entity.Property(e => e.Telefono)
			  .HasMaxLength(11)
			  .HasColumnName("telefono");
		});

		OnModelCreatingPartial(modelBuilder);
	}

	partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
