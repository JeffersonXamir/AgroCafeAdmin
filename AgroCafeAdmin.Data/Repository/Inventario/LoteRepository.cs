using AgroCafeAdmin.Core.Generic;
using AgroCafeAdmin.Core.Models.Inventario;
using AgroCafeAdmin.Data.Data;
using System.Xml.Linq;

namespace AgroCafeAdmin.Data.Repository.Inventario
{
    public class LoteRepository : GenericRepository, ILoteRepository
    {
        public LoteRepository(AgroCafeDbContext context) : base(context) { }

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
    }
}
