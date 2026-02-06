using AgroCafeAdmin.Core.Generic;
using AgroCafeAdmin.Core.Models.Bitacoras;
using AgroCafeAdmin.Core.Models.Inventario;
using AgroCafeAdmin.Data.Repository.Bitacoras;
using AgroCafeAdmin.Data.Repository.Inventario;
using AgroCafeAdmin.Service.Bitacoras;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AgroCafeAdmin.Service.Inventario
{
    public class UnidadService : IUnidadService
    {
        private readonly IUnidadRepository _repository;
        public UnidadService(IUnidadRepository repository) { _repository = repository; }

        public async Task<SpResult<List<Unidad>>> GetUnidadAsync(string transaccion, XDocument xml)
        {
            return await _repository.GetUnidad(transaccion, xml);
        }
    }
}