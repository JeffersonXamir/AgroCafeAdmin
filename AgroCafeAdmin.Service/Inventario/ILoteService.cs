using AgroCafeAdmin.Core.Generic;
using AgroCafeAdmin.Core.Models.Inventario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AgroCafeAdmin.Service.Inventario
{
    public interface ILoteService
    {
        Task<SpResult<List<Lote>>> GetLoteAsync(string transaccion, XDocument xml);
        Task<SpResult<Lote>> SetLoteAsync(string transaccion, XDocument xml);
    }
}
