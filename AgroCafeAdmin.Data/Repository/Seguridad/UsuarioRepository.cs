using AgroCafeAdmin.Core.Generic;
using AgroCafeAdmin.Core.Models.Seguridad;
using AgroCafeAdmin.Data.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AgroCafeAdmin.Data.Repository.Seguridad
{
    public class UsuarioRepository : GenericRepository, IUsuarioRepository
    {
        public UsuarioRepository(AgroCafeDbContext context) : base(context)
        {
        }

        public async Task<SpResult<List<Usuario>>> GetUsuario(string transaccion, XDocument xml)
        {
            try
            {
                var parameters = new Dictionary<string, object>
                {
                    { "@iTransaccion", $"{transaccion}" },
                    { "@iXML", xml.ToString() }
                };

                var result = await ExecuteListAsync<Usuario>("sp_GetUsuario", parameters);

                return result;
            }
            catch (Exception ex)
            {
                return new SpResult<List<Usuario>>
                {
                    Success = false,
                    Error = -1,
                    Mensaje = $"Error en repositorio: {ex.Message}",
                    Data = new List<Usuario>()
                };
            }
        }

        public async Task<SpResult<Usuario>> SetUsuario(string transaccion, XDocument xml)
        {
            try
            {
                var parameters = new Dictionary<string, object>
                {
                    { "@iTransaccion", $"{transaccion}" },
                    { "@iXML", xml.ToString() }
                };

                var result = await ExecuteSingleAsync<Usuario>("sp_SetUsuario", parameters);

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
    }
}
