using AgroCafeAdmin.Core.Generic;
using AgroCafeAdmin.Core.Models.Seguridad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AgroCafeAdmin.Service.Seguridad
{
    public interface IUsuarioService
    {
        Task<SpResult<List<Usuario>>> GetUsuarioAsync(string transaccion, XDocument xml);
        Task<SpResult<Usuario>> SetUsuarioAsync(string transaccion, XDocument xml);
    }
}
