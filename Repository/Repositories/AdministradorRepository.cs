using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
	public class AdministradorRepository : BaseRepository<Administrador>, IAdministradorRepository
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
