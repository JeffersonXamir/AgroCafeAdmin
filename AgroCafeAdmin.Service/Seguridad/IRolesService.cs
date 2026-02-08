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
    public interface IRolesService
    {
        Task<SpResult<List<Roles>>> GetRolesAsync(string transaccion, XDocument xml);
        Task<SpResult<Roles>> SetRolesAsync(string transaccion, XDocument xml);
    }
}
