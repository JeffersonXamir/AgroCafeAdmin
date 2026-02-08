using AgroCafeAdmin.Core.Models.Seguridad;

namespace AgroCafeAdmin.Service.Seguridad
{
    public interface ITokenService
    {
        string CrearToken(Usuario usuario);
    }
}
