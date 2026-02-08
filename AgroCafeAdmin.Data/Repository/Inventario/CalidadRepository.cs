using AgroCafeAdmin.Core.Generic;
using AgroCafeAdmin.Core.Models.Bitacoras;
using AgroCafeAdmin.Core.Models.Inventario;
using AgroCafeAdmin.Data.Data;
using AgroCafeAdmin.Data.Repository.Bitacoras;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AgroCafeAdmin.Data.Repository.Inventario
{
    public class CalidadRepository : GenericRepository, ICalidadRepository
    {
        public CalidadRepository(AgroCafeDbContext context) : base(context) { }

        public async Task<SpResult<List<Calidad>>> GetCalidad(string transaccion, XDocument xml)
        {
            var parameters = new Dictionary<string, object> { { "@iTransaccion", transaccion }, { "@iXML", xml.ToString() } };
            return await ExecuteListAsync<Calidad>("sp_GetCalidades", parameters);
        }
    }
}