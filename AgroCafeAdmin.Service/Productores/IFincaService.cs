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
    public interface IFincaService
    {
        Task<SpResult<List<Finca>>> GetFincasAsync(string transaccion, XDocument xml);
        Task<SpResult<Finca>> SetFincaAsync(string transaccion, XDocument xml);
    }
}
