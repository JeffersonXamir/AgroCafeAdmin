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
    public class ParcelaService : IParcelaService
    {
        private readonly IParcelaRepository _repository;
        public ParcelaService(IParcelaRepository repository) { _repository = repository; }

        public async Task<SpResult<List<Parcela>>> GetParcelasAsync(string transaccion, XDocument xml)
        {
            return await _repository.GetParcelas(transaccion, xml);
        }

        public async Task<SpResult<Parcela>> SetParcelaAsync(string transaccion, XDocument xml)
        {
            return await _repository.SetParcela(transaccion, xml);
        }
    }
}
