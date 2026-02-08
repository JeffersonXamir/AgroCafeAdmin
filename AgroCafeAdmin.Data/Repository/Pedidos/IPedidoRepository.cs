using AgroCafeAdmin.Core.Generic;
using AgroCafeAdmin.Core.Models.Pedidos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AgroCafeAdmin.Data.Repository.Pedidos
{
    public interface IPedidoRepository
    {
        Task<SpResult<List<Pedido>>> GetPedidos(string transaccion, XDocument xml);
        Task<SpResult<Pedido>> SetPedido(string transaccion, XDocument xml);
    }
}
