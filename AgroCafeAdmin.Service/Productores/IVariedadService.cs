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
    public interface IVariedadService
    {
        Task<SpResult<List<Variedad>>> GetVariedadesAsync(string transaccion, XDocument xml);
        Task<SpResult<Variedad>> SetVariedadAsync(string transaccion, XDocument xml);
    }
}
