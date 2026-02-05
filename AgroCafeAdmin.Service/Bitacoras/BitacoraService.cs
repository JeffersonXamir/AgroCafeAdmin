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
    public class BitacoraService : IBitacoraService
    {
        private readonly IBitacoraRepository _repository;
        public BitacoraService(IBitacoraRepository repository) { _repository = repository; }

        public async Task<SpResult<List<Bitacora>>> GetBitacorasAsync(string transaccion, XDocument xml)
        {
            return await _repository.GetBitacoras(transaccion, xml);
        }

        public async Task<SpResult<Bitacora>> SetBitacoraAsync(string transaccion, XDocument xml)
        {
            return await _repository.SetBitacora(transaccion, xml);
        }
    }
}
