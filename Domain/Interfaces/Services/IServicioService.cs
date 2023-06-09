﻿using Domain.Entities;

namespace Domain.Interfaces.Services
{
	public interface IServicioService : IService<Servicio>
	{
		public IQueryable<Servicio> GetAll();
	}
}