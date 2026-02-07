using AgroCafeAdmin.Core.Generic;
using AgroCafeAdmin.Core.Models.Pedidos;
using AgroCafeAdmin.Data.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AgroCafeAdmin.Data.Repository.Pedidos
{
    public class PedidoRepository : GenericRepository, IPedidoRepository
    {
        public PedidoRepository(AgroCafeDbContext context) : base(context) { }

        public async Task<SpResult<List<Pedido>>> GetPedidos(string transaccion, XDocument xml)
        {
            var parameters = new Dictionary<string, object> { { "@iTransaccion", transaccion }, { "@iXML", xml.ToString() } };
            return await ExecuteListAsync<Pedido>("sp_SetPedido", parameters);
        }

        public async Task<SpResult<Pedido>> SetPedido(string transaccion, XDocument xml)
        {
            var parameters = new Dictionary<string, object> { { "@iTransaccion", transaccion }, { "@iXML", xml.ToString() } };
            // Usamos ExecuteSingleAsync para capturar el ID y Factura generados
            return await ExecuteSingleAsync<Pedido>("sp_SetPedido", parameters);
        }
    }
}
