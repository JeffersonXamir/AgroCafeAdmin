using AgroCafeAdmin.Core.Generic;
using AgroCafeAdmin.Core.Models.Bitacoras;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AgroCafeAdmin.Service.Bitacoras
{
    public interface ILaborService
    {
        Task<SpResult<List<Labor>>> GetLaborAsync(string transaccion, XDocument xml);
    }
}
