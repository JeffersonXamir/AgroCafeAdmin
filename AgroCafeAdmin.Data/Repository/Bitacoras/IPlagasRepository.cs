using AgroCafeAdmin.Core.Generic;
using AgroCafeAdmin.Core.Models.Bitacoras;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AgroCafeAdmin.Data.Repository.Bitacoras
{
    public interface IPlagasRepository
    {
        Task<SpResult<List<Plaga>>> GetPlagas(string transaccion, XDocument xml);
    }
}
