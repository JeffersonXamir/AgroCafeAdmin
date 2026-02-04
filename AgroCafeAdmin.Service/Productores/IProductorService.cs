using AgroCafeAdmin.Core.Generic;
using AgroCafeAdmin.Core.Models.Productores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AgroCafeAdmin.Service.Productores
{
    public interface IProductorService
    {
        Task<SpResult<List<Productor>>> GetProductoresAsync(string transaccion, XDocument xml);
        Task<SpResult<Productor>> SetProductorAsync(string transaccion, XDocument xml);
    }
}
