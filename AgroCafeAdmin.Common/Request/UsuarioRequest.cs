using TallerUG.Common;

namespace AgroCafeAdmin.Common.Request
{
    public class UsuarioRequest : BaseRequest
    {
        public int Id { get; set; }
        public string Codigo { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Cedula { get; set; } = string.Empty;
        public string Contrasenia { get; set; } = string.Empty;
        public int RolId { get; set; }
        public bool Anulado { get; set; } = true;
        public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;
        public DateTime? FechaActualizacion { get; set; }
    }
}
