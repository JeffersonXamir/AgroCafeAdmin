using AgroCafeAdmin.Core.Generic;
using AgroCafeAdmin.Core.Models.Productores;
using AgroCafeAdmin.Data.Repository.Productores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AgroCafeAdmin.Service.Productores
{
    public class FincaService : IFincaService
    {
        private readonly IFincaRepository _repository;
        public FincaService(IFincaRepository repository) { _repository = repository; }

        public async Task<SpResult<List<Finca>>> GetFincasAsync(string transaccion, XDocument xml)
        {
            return await _repository.GetFincas(transaccion, xml);
        }

        public async Task<SpResult<Finca>> SetFincaAsync(string transaccion, XDocument xml)
        {
            return await _repository.SetFinca(transaccion, xml);
        }
    }
}
