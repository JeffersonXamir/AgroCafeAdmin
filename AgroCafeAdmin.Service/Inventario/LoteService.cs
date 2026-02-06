using AgroCafeAdmin.Core.Generic;
using AgroCafeAdmin.Core.Models.Inventario;
using AgroCafeAdmin.Data.Repository.Inventario;
using System.Xml.Linq;

namespace AgroCafeAdmin.Service.Inventario
{
    public class LoteService : ILoteService
    {
        private readonly ILoteRepository _repository;
        public LoteService(ILoteRepository repository) { _repository = repository; }

        public async Task<SpResult<List<Lote>>> GetLoteAsync(string transaccion, XDocument xml)
        {
            return await _repository.GetLotes(transaccion, xml);
        }

        public async Task<SpResult<Lote>> SetLoteAsync(string transaccion, XDocument xml)
        {
            return await _repository.SetLote(transaccion, xml);
        }
    }
}