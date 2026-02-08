using AgroCafeAdmin.Core.Generic;
using AgroCafeAdmin.Core.Models.Clientes;
using AgroCafeAdmin.Data.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AgroCafeAdmin.Data.Repository.Clientes
{
    public class ClienteRepository : GenericRepository, IClienteRepository
    {
        public ClienteRepository(AgroCafeDbContext context) : base(context) { }

        public async Task<SpResult<List<Cliente>>> GetClientes(string transaccion, XDocument xml)
        {
            var parameters = new Dictionary<string, object> { { "@iTransaccion", transaccion }, { "@iXML", xml.ToString() } };
            return await ExecuteListAsync<Cliente>("sp_GetCliente", parameters);
        }

        public async Task<SpResult<Cliente>> SetCliente(string transaccion, XDocument xml)
        {
            var parameters = new Dictionary<string, object> { { "@iTransaccion", transaccion }, { "@iXML", xml.ToString() } };
            return await ExecuteSingleAsync<Cliente>("sp_SetCliente", parameters);
        }
    }
}
