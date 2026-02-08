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
    public interface IRolesRepository
    {
        Task<SpResult<List<Roles>>> GetRoles(string transaccion, XDocument xml);
        Task<SpResult<Roles>> SetRoles(string transaccion, XDocument xml);
    }
}
