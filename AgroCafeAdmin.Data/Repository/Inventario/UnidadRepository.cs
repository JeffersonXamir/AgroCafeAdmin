using AgroCafeAdmin.Core.Generic;
using AgroCafeAdmin.Core.Models.Inventario;
using AgroCafeAdmin.Data.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AgroCafeAdmin.Data.Repository.Inventario
{
    public class UnidadRepository : GenericRepository, IUnidadRepository
    {
        public UnidadRepository(AgroCafeDbContext context) : base(context) { }

        public async Task<SpResult<List<Unidad>>> GetUnidad(string transaccion, XDocument xml)
        {
            var parameters = new Dictionary<string, object> { { "@iTransaccion", transaccion }, { "@iXML", xml.ToString() } };
            return await ExecuteListAsync<Unidad>("sp_GetUnidades", parameters);
        }
    }
}