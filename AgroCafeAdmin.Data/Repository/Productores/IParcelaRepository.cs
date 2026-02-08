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
    public interface IParcelaRepository
    {
        Task<SpResult<List<Parcela>>> GetParcelas(string transaccion, XDocument xml);
        Task<SpResult<Parcela>> SetParcela(string transaccion, XDocument xml);
    }
}
