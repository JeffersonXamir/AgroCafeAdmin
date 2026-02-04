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
    public interface IFincaRepository
    {
        Task<SpResult<List<Finca>>> GetFincas(string transaccion, XDocument xml);
        Task<SpResult<Finca>> SetFinca(string transaccion, XDocument xml);
    }
}
