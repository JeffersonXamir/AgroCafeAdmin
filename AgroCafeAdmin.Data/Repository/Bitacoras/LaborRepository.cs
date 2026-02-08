using AgroCafeAdmin.Core.Generic;
using AgroCafeAdmin.Core.Models.Bitacoras;
using AgroCafeAdmin.Data.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AgroCafeAdmin.Data.Repository.Bitacoras
{
    public class LaborRepository : GenericRepository, ILaborRepository
    {
        public LaborRepository(AgroCafeDbContext context) : base(context) { }

        public async Task<SpResult<List<Labor>>> GetLabor(string transaccion, XDocument xml)
        {
            var parameters = new Dictionary<string, object> { { "@iTransaccion", transaccion }, { "@iXML", xml.ToString() } };
            return await ExecuteListAsync<Labor>("sp_GetBitacora", parameters);
        }
    }
}
