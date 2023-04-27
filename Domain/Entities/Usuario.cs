using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Domain.Entities
{
	public class Usuario
	{
        public int Id { get; set; }
        public string Cedula { get; set; }
        public int RolID { get; set; }
        public string Clave { get; set; }
        public Administrador Administrador { get; set; }
        public Estudiante Estudiante { get; set; }
        public Rol Rol { get; set; }
    }
}
