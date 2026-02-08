using System.Xml.Linq;
using AgroCafeAdmin.Core.Generic;
using AgroCafeAdmin.Core.Models.Seguridad;
using AgroCafeAdmin.Data.Repository.Seguridad;

namespace AgroCafeAdmin.Service.Seguridad
{
    public class AutorizacionService: IAutorizacionService
    {
        private readonly IAutorizacionRepository _repository;
        private readonly ITokenService _tokenService;
        
        public AutorizacionService(IAutorizacionRepository repository, ITokenService tokenService)
        {
            _repository = repository;
            _tokenService = tokenService;
        }

        public async Task<SpResult<Autorizacion>> VerificarAutorizacionAsync(string transaccion, XDocument xml)
        {

            try
            {
                // 1. Llamar al repositorio
                var result = await _repository.VerificarAutorizacion(transaccion, xml);

                // 2. Validar resultado del repositorio
                if (!result.Success)
                {
                    return new SpResult<Autorizacion>
                    {
                        Success = false,
                        Mensaje = $"No se pudo verificar el usuario",
                        Data = null,
                    };
                }

                Autorizacion autorizacion = new Autorizacion();
                autorizacion.Token = _tokenService.CrearToken(result.Data);

                return new SpResult<Autorizacion>
                {
                    Success = true,
                    Mensaje = $"Se encontro 1 registro",
                    Data = autorizacion
                };
            }
            catch (Exception ex)
            {
                return new SpResult<Autorizacion>
                {
                    Success = false,
                    Error = -1,
                    Mensaje = $"Error interno en el servicio: {ex.Message}",
                    Data = new Autorizacion()
                };
            }
        }
    }
}
