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
    public interface ICalidadRepository
    {
        Task<SpResult<List<Calidad>>> GetCalidad(string transaccion, XDocument xml);
    }
}
