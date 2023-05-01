using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Domain.Entities
{
	public class Administrador
	{
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Correo { get; set; }
        public int UserID { get; set; }
        public string Telefono { get; set; }
        public Usuario Usuario { get; set; }
    }
}
