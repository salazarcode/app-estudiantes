using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces.Repositories;

namespace Repository.Repositories
{
    public class AdministradorRepository : AbstractRepository<Administrador>, IAdministradorRepository
	{
		public AdministradorRepository(DatabaseContext dbContext) : base(dbContext)
		{
		}

		public IEnumerable<Administrador> GetAllWithUser()
		{
			return DbContext.Set<Administrador>().Include(x => x.Usuario).ToList();
		}

	}
}
