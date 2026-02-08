using AgroCafeAdmin.Core.Generic;
using AgroCafeAdmin.Core.Models.Pedidos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AgroCafeAdmin.Service.Pedidos
{
    public interface IPedidoService
    {
        Task<SpResult<List<Pedido>>> GetPedidoAsync(string transaccion, XDocument xml);
        Task<SpResult<Pedido>> SetPedidoAsync(string transaccion, XDocument xml);
    }
}
