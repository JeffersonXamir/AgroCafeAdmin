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
    public class VariedadService : IVariedadService
    {
        private readonly IVariedadRepository _repository;
        public VariedadService(IVariedadRepository repository) { _repository = repository; }

        public async Task<SpResult<List<Variedad>>> GetVariedadesAsync(string transaccion, XDocument xml)
        {
            return await _repository.GetVariedades(transaccion, xml);
        }

        public async Task<SpResult<Variedad>> SetVariedadAsync(string transaccion, XDocument xml)
        {
            return await _repository.SetVariedad(transaccion, xml);
        }
    }
}
