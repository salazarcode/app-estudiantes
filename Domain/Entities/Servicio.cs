using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Domain.Entities
{
	public class Servicio
	{
        public int Id { get; set; }
        public string Titulo { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public bool Estado { get; set; }
        public ICollection<Estudiante> Estudiantes { get; set; }
    }
}
