
using Microsoft.AspNetCore.DataProtection.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Repository;
using Repository.Abstract;
using Repository.Repositories;
using System.Xml;
using Domain.Entities;

namespace API
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.

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