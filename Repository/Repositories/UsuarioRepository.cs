using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Repository.Repositories
{
    public class UsuarioRepository : AbstractRepository<Usuario>, IUsuarioRepository
	{
		public UsuarioRepository(DatabaseContext dbContext) : base(dbContext)
		{
		}

		public IEnumerable<Usuario> GetWithRol()
		{
			return this.Get().Include(x => x.Rol).ToList();
		}
	}
}
