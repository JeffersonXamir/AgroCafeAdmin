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
    public interface IBitacoraRepository
    {
        Task<SpResult<List<Bitacora>>> GetBitacoras(string transaccion, XDocument xml);
        Task<SpResult<Bitacora>> SetBitacora(string transaccion, XDocument xml);
    }
}
