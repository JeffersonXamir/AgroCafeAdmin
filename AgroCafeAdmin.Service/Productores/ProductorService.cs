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
    public class ProductorService : IProductorService
    {
        private readonly IProductorRepository _repository;
        public ProductorService(IProductorRepository repository) { _repository = repository; }

        public async Task<SpResult<List<Productor>>> GetProductoresAsync(string transaccion, XDocument xml)
        {
            return await _repository.GetProductores(transaccion, xml);
        }

        public async Task<SpResult<Productor>> SetProductorAsync(string transaccion, XDocument xml)
        {
            return await _repository.SetProductor(transaccion, xml);
        }
    }
}
