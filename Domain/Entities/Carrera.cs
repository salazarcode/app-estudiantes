namespace Domain.Entities
{
	public class Carrera
	{
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public ICollection<Estudiante> Estudiantes { get; set; }
    }
}
