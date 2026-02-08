using AgroCafeAdmin.Core.Generic;
using AgroCafeAdmin.Core.Models.Pedidos;
using AgroCafeAdmin.Data.Repository.Pedidos;
using System.Xml.Linq;

namespace AgroCafeAdmin.Service.Pedidos
{
    public class PedidoService : IPedidoService
    {
        private readonly IPedidoRepository _repository;
        public PedidoService(IPedidoRepository repository) { _repository = repository; }

        public async Task<SpResult<List<Pedido>>> GetPedidoAsync(string transaccion, XDocument xml)
        {
            return await _repository.GetPedidos(transaccion, xml);
        }

        public async Task<SpResult<Pedido>> SetPedidoAsync(string transaccion, XDocument xml)
        {
            return await _repository.SetPedido(transaccion, xml);
        }
    }
}