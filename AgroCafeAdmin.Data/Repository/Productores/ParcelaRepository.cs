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
    public class ParcelaRepository : GenericRepository, IParcelaRepository
    {
        public ParcelaRepository(AgroCafeDbContext context) : base(context) { }

        public async Task<SpResult<List<Parcela>>> GetParcelas(string transaccion, XDocument xml)
        {
            var parameters = new Dictionary<string, object> { { "@iTransaccion", transaccion }, { "@iXML", xml.ToString() } };
            return await ExecuteListAsync<Parcela>("sp_GetParcela", parameters);
        }

        public async Task<SpResult<Parcela>> SetParcela(string transaccion, XDocument xml)
        {
            var parameters = new Dictionary<string, object> { { "@iTransaccion", transaccion }, { "@iXML", xml.ToString() } };
            return await ExecuteSingleAsync<Parcela>("sp_SetParcela", parameters);
        }
    }
}
