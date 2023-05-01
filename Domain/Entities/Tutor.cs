using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Domain.Entities
{
	public class Tutor
	{
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public string Ci { get; set; }
        public ICollection<Estudiante> Estudiantes { get; set; }
    }
}
