namespace Domain.Entities
{
	public class Estudiante
	{
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Correo { get; set; }
        public string Direccion { get; set; }
        public int CarreraID { get; set; }
        public int TutorID { get; set; }
        public int ServicioID { get; set; }
        public int UserID { get; set; }
        public string Telefono { get; set; }
        public Carrera Carrera { get; set; }
        public Tutor Tutor { get; set; }
        public Servicio Servicio { get; set; }
        public Usuario Usuario { get; set; }
    }
}
