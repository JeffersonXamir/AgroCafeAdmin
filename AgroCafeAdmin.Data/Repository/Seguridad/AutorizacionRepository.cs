using AgroCafeAdmin.Core.Generic;
using AgroCafeAdmin.Core.Models.Seguridad;
using AgroCafeAdmin.Data.Data;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AgroCafeAdmin.Data.Repository.Seguridad
{
    public class AutorizacionRepository : GenericRepository, IAutorizacionRepository
    {
        private readonly IConfiguration _configuration;
        public AutorizacionRepository(AgroCafeDbContext context, IConfiguration configuration) : base(context)
        {
            _configuration = configuration;
        }

        public async Task<SpResult<Usuario>> VerificarAutorizacion(string transaccion, XDocument xml)
        {
            try
            {
                var parameters = new Dictionary<string, object>
                {
                    { "@iTransaccion", $"{transaccion}" },
                    { "@iXML", xml.ToString() }
                };

                var result = await ExecuteSingleAsync<Usuario>("sp_GetAutorizacion", parameters);

                return result;
            }
            catch (Exception ex)
            {
                return new SpResult<Usuario>
                {
                    Success = false,
                    Error = -1,
                    Mensaje = $"Error en repositorio: {ex.Message}",
                    Data = new Usuario()
                };
            }
        }

        public string GetApiToken()
        {
            return _configuration["AppSettings:Token"]
                   ?? throw new InvalidOperationException("API token not found.");
        }
    }
}
