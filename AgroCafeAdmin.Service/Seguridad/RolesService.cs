using AgroCafeAdmin.Core.Generic;
using AgroCafeAdmin.Core.Models.Seguridad;
using AgroCafeAdmin.Data.Repository.Seguridad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AgroCafeAdmin.Service.Seguridad
{
    public class RolesService : IRolesService
    {
        private readonly IRolesRepository _repository;

        public RolesService(IRolesRepository repository)
        {
            _repository = repository;
        }

        public async Task<SpResult<List<Roles>>> GetRolesAsync(string transaccion, XDocument xml)
        {

            try
            {
                // 1. Llamar al repositorio
                var result = await _repository.GetRoles(transaccion, xml);

                // 2. Validar resultado del repositorio
                if (!result.Success)
                {
                    return new SpResult<List<Roles>>
                    {
                        Success = false,
                        Mensaje = $"No se pudo verificar el usuario",
                        Data = null,
                    };
                }


                return new SpResult<List<Roles>>
                {
                    Success = true,
                    Mensaje = $"Se encontraron {result.Data.Count} registros",
                    Data = result.Data
                };
            }
            catch (Exception ex)
            {
                return new SpResult<List<Roles>>
                {
                    Success = false,
                    Error = -1,
                    Mensaje = $"Error interno en el servicio: {ex.Message}",
                    Data = new List<Roles>()
                };
            }
        }

        public async Task<SpResult<Roles>> SetRolesAsync(string transaccion, XDocument xml)
        {

            try
            {
                // 1. Llamar al repositorio
                var result = await _repository.SetRoles(transaccion, xml);

                // 2. Validar resultado del repositorio
                if (!result.Success)
                {
                    return new SpResult<Roles>
                    {
                        Success = false,
                        Mensaje = $"Error al actualizar el registro.",
                        Data = null,
                    };
                }


                return new SpResult<Roles>
                {
                    Success = true,
                    Mensaje = $"Se actualizo un registro.",
                    Data = result.Data
                };
            }
            catch (Exception ex)
            {
                return new SpResult<Roles>
                {
                    Success = false,
                    Error = -1,
                    Mensaje = $"Error interno en el servicio: {ex.Message}",
                    Data = new Roles()
                };
            }
        }
    }
}
