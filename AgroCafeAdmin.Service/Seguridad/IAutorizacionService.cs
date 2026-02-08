using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using AgroCafeAdmin.Core.Generic;
using AgroCafeAdmin.Core.Models.Seguridad;

namespace AgroCafeAdmin.Service.Seguridad
{
    public interface IAutorizacionService
    {
        Task<SpResult<Autorizacion>> VerificarAutorizacionAsync(string transaccion, XDocument xml);
    }
}
