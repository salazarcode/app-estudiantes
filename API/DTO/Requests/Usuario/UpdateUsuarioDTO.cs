namespace API.DTO.Requests.Usuario
{
    public class UpdateUsuarioDTO
    {
        public int? id { get; set; }
        public string? Cedula { get; set; }
        public int? RoleId { get; set; }
        public string? Clave { get; set; }
    }
}
