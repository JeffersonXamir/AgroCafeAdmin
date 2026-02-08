using AgroCafeAdmin.Core.Generic;
using AgroCafeAdmin.Core.Models.Inventario;
using AgroCafeAdmin.Data.Data;
using System.Xml.Linq;

namespace AgroCafeAdmin.Data.Repository.Inventario
{
    public class InventarioRepository : GenericRepository, IInventarioRepository
    {
        public InventarioRepository(AgroCafeDbContext context) : base(context) { }

        public async Task<SpResult<List<Lote>>> GetLotes(string transaccion, XDocument xml)
        {
            var parameters = new Dictionary<string, object> { { "@iTransaccion", transaccion }, { "@iXML", xml.ToString() } };
            return await ExecuteListAsync<Lote>("sp_GetLote", parameters);
        }

        public async Task<SpResult<Lote>> SetLote(string transaccion, XDocument xml)
        {
            var parameters = new Dictionary<string, object> { { "@iTransaccion", transaccion }, { "@iXML", xml.ToString() } };
            return await ExecuteSingleAsync<Lote>("sp_SetLote", parameters);
        }

        public async Task<SpResult<List<Movimiento>>> GetMovimientos(string transaccion, XDocument xml)
        {
            var parameters = new Dictionary<string, object> { { "@iTransaccion", transaccion }, { "@iXML", xml.ToString() } };
            return await ExecuteListAsync<Movimiento>("sp_GetMovimientos", parameters);
        }
    }
}
