using AgroCafeAdmin.Core.Generic;
using AgroCafeAdmin.Core.Models.Productores;
using AgroCafeAdmin.Data.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AgroCafeAdmin.Data.Repository.Productores
{
    public class VariedadRepository : GenericRepository, IVariedadRepository
    {
        public VariedadRepository(AgroCafeDbContext context) : base(context) { }

        public async Task<SpResult<List<Variedad>>> GetVariedades(string transaccion, XDocument xml)
        {
            var parameters = new Dictionary<string, object> { { "@iTransaccion", transaccion }, { "@iXML", xml.ToString() } };
            return await ExecuteListAsync<Variedad>("sp_GetVariedad", parameters);
        }

        public async Task<SpResult<Variedad>> SetVariedad(string transaccion, XDocument xml)
        {
            var parameters = new Dictionary<string, object> { { "@iTransaccion", transaccion }, { "@iXML", xml.ToString() } };
            return await ExecuteSingleAsync<Variedad>("sp_SetVariedad", parameters);
        }
    }
}
