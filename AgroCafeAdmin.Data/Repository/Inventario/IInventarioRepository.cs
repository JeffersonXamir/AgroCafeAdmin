using AgroCafeAdmin.Core.Generic;
using AgroCafeAdmin.Core.Models.Inventario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AgroCafeAdmin.Data.Repository.Inventario
{
    public interface IInventarioRepository
    {
        Task<SpResult<List<Lote>>> GetLotes(string transaccion, XDocument xml);
        Task<SpResult<Lote>> SetLote(string transaccion, XDocument xml);
        Task<SpResult<List<Movimiento>>> GetMovimientos(string transaccion, XDocument xml);
    }
}
