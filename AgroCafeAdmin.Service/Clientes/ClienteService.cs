using AgroCafeAdmin.Core.Generic;
using AgroCafeAdmin.Core.Models.Clientes;
using AgroCafeAdmin.Data.Repository.Clientes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AgroCafeAdmin.Service.Clientes
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _repository;
        public ClienteService(IClienteRepository repository) { _repository = repository; }

        public async Task<SpResult<List<Cliente>>> GetClientesAsync(string transaccion, XDocument xml)
        {
            return await _repository.GetClientes(transaccion, xml);
        }

        public async Task<SpResult<Cliente>> SetClienteAsync(string transaccion, XDocument xml)
        {
            return await _repository.SetCliente(transaccion, xml);
        }
    }
}
