
using Microsoft.AspNetCore.DataProtection.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Repository;
using Repository.Repositories;
using System.Xml;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Interfaces.Tools;
using Domain.Services;
using Infrastructure;

namespace API
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.

			builder.Services.AddAutoMapper(typeof(Program));
			builder.Services.AddControllers();
			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();

			builder.Services.AddDbContext<DatabaseContext>(options =>
			{
				options.UseSqlServer(builder.Configuration.GetConnectionString("main"));
			});

			builder.Services.AddTransient<IUsuarioRepository, UsuarioRepository>();
			builder.Services.AddTransient<IAdministradorRepository, AdministradorRepository>();
			builder.Services.AddTransient<IRolRepository, RolRepository>();
			builder.Services.AddTransient<ITutorRepository, TutorRepository>();
			builder.Services.AddTransient<IServicioRepository, ServicioRepository>();
			builder.Services.AddTransient<IEstudianteRepository, EstudianteRepository>();
			builder.Services.AddTransient<ICarreraRepository, CarreraRepository>();

			builder.Services.AddTransient<IUsuarioService, UsuarioService>();
			builder.Services.AddTransient<IAdministradorService, AdministradorService>();
			builder.Services.AddTransient<IRolService, RolService>();
			builder.Services.AddTransient<ITutorService, TutorService>();
			builder.Services.AddTransient<IServicioService, ServicioService>();
			builder.Services.AddTransient<IEstudianteService, EstudianteService>();
			builder.Services.AddTransient<ICarreraService, CarreraService>();
			
			builder.Services.AddTransient<IUsuarioService, UsuarioService>();
			builder.Services.AddTransient<IRolService, RolService>();


			builder.Services.AddSingleton<IHasher, Hashing>();

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseAuthorization();


			app.MapControllers();

			app.Run();
		}
	}
}