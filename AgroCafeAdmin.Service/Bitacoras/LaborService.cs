using AgroCafeAdmin.Core.Generic;
using AgroCafeAdmin.Core.Models.Bitacoras;
using AgroCafeAdmin.Data.Repository.Bitacoras;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AgroCafeAdmin.Service.Bitacoras
{
    public class LaborService : ILaborService
    {
        private readonly ILaborRepository _repository;
        public LaborService(ILaborRepository repository) { _repository = repository; }

        public async Task<SpResult<List<Labor>>> GetLaborAsync(string transaccion, XDocument xml)
        {
            return await _repository.GetLabor(transaccion, xml);
        }
    }
}
