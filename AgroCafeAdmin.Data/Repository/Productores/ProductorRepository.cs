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
    public class ProductorRepository : GenericRepository, IProductorRepository
    {
        public ProductorRepository(AgroCafeDbContext context) : base(context) { }

        public async Task<SpResult<List<Productor>>> GetProductores(string transaccion, XDocument xml)
        {
            var parameters = new Dictionary<string, object> { { "@iTransaccion", transaccion }, { "@iXML", xml.ToString() } };
            return await ExecuteListAsync<Productor>("sp_GetProductor", parameters);
        }

        public async Task<SpResult<Productor>> SetProductor(string transaccion, XDocument xml)
        {
            var parameters = new Dictionary<string, object> { { "@iTransaccion", transaccion }, { "@iXML", xml.ToString() } };
            return await ExecuteSingleAsync<Productor>("sp_SetProductor", parameters);
        }
    }
}
