using AgroCafeAdmin.Core.Generic;
using AgroCafeAdmin.Core.Models.Clientes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AgroCafeAdmin.Service.Clientes
{
    public interface IClienteService
    {
        Task<SpResult<List<Cliente>>> GetClientesAsync(string transaccion, XDocument xml);
        Task<SpResult<Cliente>> SetClienteAsync(string transaccion, XDocument xml);
    }
}
