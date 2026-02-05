using AgroCafeAdmin.Core.Generic;
using AgroCafeAdmin.Core.Models.Bitacoras;
using AgroCafeAdmin.Core.Models.Productores;
using AgroCafeAdmin.Data.Data;
using AgroCafeAdmin.Data.Repository.Productores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AgroCafeAdmin.Data.Repository.Bitacoras
{
    public class PlagasRepository : GenericRepository, IPlagasRepository
    {
        public PlagasRepository(AgroCafeDbContext context) : base(context) { }

        public async Task<SpResult<List<Plaga>>> GetPlagas(string transaccion, XDocument xml)
        {
            var parameters = new Dictionary<string, object> { { "@iTransaccion", transaccion }, { "@iXML", xml.ToString() } };
            return await ExecuteListAsync<Plaga>("sp_GetBitacora", parameters);
        }
    }
}
