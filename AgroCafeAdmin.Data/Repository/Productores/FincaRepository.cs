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
    public class FincaRepository : GenericRepository, IFincaRepository
    {
        public FincaRepository(AgroCafeDbContext context) : base(context) { }

        public async Task<SpResult<List<Finca>>> GetFincas(string transaccion, XDocument xml)
        {
            var parameters = new Dictionary<string, object> { { "@iTransaccion", transaccion }, { "@iXML", xml.ToString() } };
            return await ExecuteListAsync<Finca>("sp_GetFinca", parameters);
        }

        public async Task<SpResult<Finca>> SetFinca(string transaccion, XDocument xml)
        {
            var parameters = new Dictionary<string, object> { { "@iTransaccion", transaccion }, { "@iXML", xml.ToString() } };
            return await ExecuteSingleAsync<Finca>("sp_SetFinca", parameters);
        }
    }
}
