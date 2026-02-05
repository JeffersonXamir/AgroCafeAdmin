using AgroCafeAdmin.Core.Generic;
using AgroCafeAdmin.Core.Models.Bitacoras;
using AgroCafeAdmin.Data.Data;
using System.Xml.Linq;

namespace AgroCafeAdmin.Data.Repository.Bitacoras
{
    public class BitacoraRepository : GenericRepository, IBitacoraRepository
    {
        public BitacoraRepository(AgroCafeDbContext context) : base(context) { }

        public async Task<SpResult<List<Bitacora>>> GetBitacoras(string transaccion, XDocument xml)
        {
            var parameters = new Dictionary<string, object> { { "@iTransaccion", transaccion }, { "@iXML", xml.ToString() } };
            return await ExecuteListAsync<Bitacora>("sp_GetBitacora", parameters);
        }

        public async Task<SpResult<Bitacora>> SetBitacora(string transaccion, XDocument xml)
        {
            var parameters = new Dictionary<string, object> { { "@iTransaccion", transaccion }, { "@iXML", xml.ToString() } };
            return await ExecuteSingleAsync<Bitacora>("sp_SetBitacora", parameters);
        }
    }
}
