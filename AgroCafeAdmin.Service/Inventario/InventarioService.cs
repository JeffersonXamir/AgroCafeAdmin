using AgroCafeAdmin.Core.Generic;
using AgroCafeAdmin.Core.Models.Inventario;
using AgroCafeAdmin.Data.Repository.Inventario;
using System.Xml.Linq;

namespace AgroCafeAdmin.Service.Inventario
{
    public class InventarioService : IInventarioService
    {
        private readonly IInventarioRepository _repository;
        public InventarioService(IInventarioRepository repository) { _repository = repository; }

        public async Task<SpResult<List<Lote>>> GetLoteAsync(string transaccion, XDocument xml)
        {
            return await _repository.GetLotes(transaccion, xml);
        }

        public async Task<SpResult<Lote>> SetLoteAsync(string transaccion, XDocument xml)
        {
            return await _repository.SetLote(transaccion, xml);
        }

        public async Task<SpResult<List<Movimiento>>> GetMovimientosAsync(string transaccion, XDocument xml)
        {
            return await _repository.GetMovimientos(transaccion, xml);
        }
    }
}