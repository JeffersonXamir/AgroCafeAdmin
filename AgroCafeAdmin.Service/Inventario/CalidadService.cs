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
    public class CalidadService : ICalidadService
    {
        private readonly ICalidadRepository _repository;
        public CalidadService(ICalidadRepository repository) { _repository = repository; }

        public async Task<SpResult<List<Calidad>>> GetCalidadAsync(string transaccion, XDocument xml)
        {
            return await _repository.GetCalidad(transaccion, xml);
        }
    }
}