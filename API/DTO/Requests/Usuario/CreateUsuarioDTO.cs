namespace API.DTO.Requests.Usuario
{
    public class CreateUsuarioDTO
    {
        public string? Cedula { get; set; }
        public int? RoleId { get; set; }
        public string? Clave { get; set; }
    }
}
