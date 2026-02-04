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
    public interface IParcelaService
    {
        Task<SpResult<List<Parcela>>> GetParcelasAsync(string transaccion, XDocument xml);
        Task<SpResult<Parcela>> SetParcelaAsync(string transaccion, XDocument xml);
    }
}
