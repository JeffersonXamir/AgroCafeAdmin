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
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _repository;

        public UsuarioService(IUsuarioRepository repository)
        {
            _repository = repository;
        }

        public async Task<SpResult<List<Usuario>>> GetUsuarioAsync(string transaccion, XDocument xml)
        {

            try
            {
                // 1. Llamar al repositorio
                var result = await _repository.GetUsuario(transaccion, xml);

                // 2. Validar resultado del repositorio
                if (!result.Success)
                {
                    return new SpResult<List<Usuario>>
                    {
                        Success = false,
                        Mensaje = $"No se pudo verificar el usuario",
                        Data = null,
                    };
                }


                return new SpResult<List<Usuario>>
                {
                    Success = true,
                    Mensaje = $"Se encontraron {result.Data.Count} registros",
                    Data = result.Data
                };
            }
            catch (Exception ex)
            {
                return new SpResult<List<Usuario>>
                {
                    Success = false,
                    Error = -1,
                    Mensaje = $"Error interno en el servicio: {ex.Message}",
                    Data = new List<Usuario>()
                };
            }
        }

        public async Task<SpResult<Usuario>> SetUsuarioAsync(string transaccion, XDocument xml)
        {

            try
            {
                // 1. Llamar al repositorio
                var result = await _repository.SetUsuario(transaccion, xml);

                // 2. Validar resultado del repositorio
                if (!result.Success)
                {
                    return new SpResult<Usuario>
                    {
                        Success = false,
                        Mensaje = $"Error al actualizar el registro.",
                        Data = null,
                    };
                }


                return new SpResult<Usuario>
                {
                    Success = true,
                    Mensaje = $"Se actualizo un registro.",
                    Data = result.Data
                };
            }
            catch (Exception ex)
            {
                return new SpResult<Usuario>
                {
                    Success = false,
                    Error = -1,
                    Mensaje = $"Error interno en el servicio: {ex.Message}",
                    Data = new Usuario()
                };
            }
        }
    }
}
