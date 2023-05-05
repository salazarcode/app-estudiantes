using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Repository.Abstract;

namespace Repository.Repositories
{
	public interface IAdministradorRepository : IRepository<Administrador>
	{
		public IEnumerable<Administrador> GetAllWithUser();
	}
}
