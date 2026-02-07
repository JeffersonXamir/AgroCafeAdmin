using AgroCafeAdmin.Core.Generic;
using AgroCafeAdmin.Core.Models.Clientes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AgroCafeAdmin.Data.Repository.Clientes
{
    public interface IClienteRepository
    {
        Task<SpResult<List<Cliente>>> GetClientes(string transaccion, XDocument xml);
        Task<SpResult<Cliente>> SetCliente(string transaccion, XDocument xml);
    }
}
