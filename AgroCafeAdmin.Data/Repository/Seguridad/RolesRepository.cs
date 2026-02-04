using AgroCafeAdmin.Core.Generic;
using AgroCafeAdmin.Core.Models.Seguridad;
using AgroCafeAdmin.Data.Data;
using System.Xml.Linq;

namespace AgroCafeAdmin.Data.Repository.Seguridad
{
    public class RolesRepository : GenericRepository, IRolesRepository
    {
        public RolesRepository(AgroCafeDbContext context) : base(context)
        {
        }

        public async Task<SpResult<List<Roles>>> GetRoles(string transaccion, XDocument xml)
        {
            try
            {
                var parameters = new Dictionary<string, object>
                {
                    { "@iTransaccion", $"{transaccion}" },
                    { "@iXML", xml.ToString() }
                };

                var result = await ExecuteListAsync<Roles>("sp_GetRoles", parameters);

                return result;
            }
            catch (Exception ex)
            {
                return new SpResult<List<Roles>>
                {
                    Success = false,
                    Error = -1,
                    Mensaje = $"Error en repositorio: {ex.Message}",
                    Data = new List<Roles>()
                };
            }
        }

        public async Task<SpResult<Roles>> SetRoles(string transaccion, XDocument xml)
        {
            try
            {
                var parameters = new Dictionary<string, object>
                {
                    { "@iTransaccion", $"{transaccion}" },
                    { "@iXML", xml.ToString() }
                };

                var result = await ExecuteSingleAsync<Roles>("sp_SetRoles", parameters);

                return result;
            }
            catch (Exception ex)
            {
                return new SpResult<Roles>
                {
                    Success = false,
                    Error = -1,
                    Mensaje = $"Error en repositorio: {ex.Message}",
                    Data = new Roles()
                };
            }
        }
    }
}
