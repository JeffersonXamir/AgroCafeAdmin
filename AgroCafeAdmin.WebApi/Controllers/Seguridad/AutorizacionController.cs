using AgroCafeAdmin.Common.Request;
using AgroCafeAdmin.Core.Generic;
using AgroCafeAdmin.Core.Models.Seguridad;
using AgroCafeAdmin.Data.Utils;
using AgroCafeAdmin.Service.Seguridad;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace AgroCafeAdmin.API.Controllers.Seguridad
{
    [ApiController]
    [Route("api/[controller]")]
    public class AutorizacionController : Controller
    {
        private readonly IAutorizacionService _authService;
        public AutorizacionController(IAutorizacionService authService)
        {
            _authService = authService;
        }


        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> VerificarAutorizacionAsync([FromBody] UsuarioRequest request)
        {
            try
            {
                XDocument xml = XmlSerializerHelper.GetXml(request);
                var xmlString = XmlSerializerHelper.SerializeToXml(request);

                var result = await _authService.VerificarAutorizacionAsync(request.Transaccion, xml);

                if (!result.Success)
                {
                    return BadRequest(new
                    {
                        Success = false,
                        Message = result.Mensaje,
                        errorCode = result.Error
                    });
                }

                return Ok(new ApiResponse<Autorizacion>
                {
                    Success = true,
                    Message = result.Mensaje,
                    Data = result.Data
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse<object>
                {
                    Success = false,
                    Message = "Error interno del servidor",
                    ErrorCode = 500,
                    Data = new { detalle = ex.Message }
                });
            }
            finally
            {

            }
        }
    }
}
