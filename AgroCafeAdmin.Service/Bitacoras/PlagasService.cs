using AgroCafeAdmin.Core.Generic;
using AgroCafeAdmin.Core.Models.Bitacoras;
using AgroCafeAdmin.Core.Models.Productores;
using AgroCafeAdmin.Data.Repository.Bitacoras;
using AgroCafeAdmin.Data.Repository.Productores;
using AgroCafeAdmin.Service.Productores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AgroCafeAdmin.Service.Bitacoras
{
    public class PlagasService : IPlagasService
    {
        private readonly IPlagasRepository _repository;
        public PlagasService(IPlagasRepository repository) { _repository = repository; }

        public async Task<SpResult<List<Plaga>>> GetPlagasAsync(string transaccion, XDocument xml)
        {
            return await _repository.GetPlagas(transaccion, xml);
        }        
    }
}
