using AgroCafeAdmin.Core.Generic;
using AgroCafeAdmin.Core.Models.Productores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AgroCafeAdmin.Data.Repository.Productores
{
    public interface IVariedadRepository
    {
        Task<SpResult<List<Variedad>>> GetVariedades(string transaccion, XDocument xml);
        Task<SpResult<Variedad>> SetVariedad(string transaccion, XDocument xml);
    }
}
