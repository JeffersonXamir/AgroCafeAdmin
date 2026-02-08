using AgroCafeAdmin.Core.Generic;
using AgroCafeAdmin.Core.Models.Seguridad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AgroCafeAdmin.Data.Repository.Seguridad
{
    public interface IUsuarioRepository
    {
        Task<SpResult<List<Usuario>>> GetUsuario(string transaccion, XDocument xml);
        Task<SpResult<Usuario>> SetUsuario(string transaccion, XDocument xml);
    }
}
