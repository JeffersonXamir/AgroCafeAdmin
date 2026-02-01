using AgroCafeAdmin.Common.Request;
using AgroCafeAdmin.Core.Generic;
using AgroCafeAdmin.Core.Models.Seguridad;
using AgroCafeAdmin.Data.Utils;
using AgroCafeAdmin.Service.Seguridad;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace AgroCafeAdmin.WebApi.Controllers.Seguridad
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class UsuarioController : Controller
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        /// <summary>
        /// Obtiene todos los usuarios por transaccion
        /// </summary>
        /// <returns>Lista de carros</returns>
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> GetUsuarioTransaccion([FromBody] UsuarioRequest request)
        {
            try
            {
                XDocument xml = XmlSerializerHelper.GetXml(request);
                var xmlString = XmlSerializerHelper.SerializeToXml(request);

                var result = await _usuarioService.GetUsuarioAsync(request.Transaccion, xml);

                if (!result.Success)
                {
                    return BadRequest(new
                    {
                        Success = false,
                        Message = result.Mensaje,
                        errorCode = result.Error
                    });
                }

                return Ok(new ApiResponse<List<Usuario>>
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

        /// <summary>
        /// Obtiene todos los usuarios por transaccion
        /// </summary>
        /// <returns>Lista de carros</returns>
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> SetUsuarioTransaccion([FromBody] UsuarioRequest request)
        {
            try
            {
                XDocument xml = XmlSerializerHelper.GetXml(request);
                var xmlString = XmlSerializerHelper.SerializeToXml(request);

                var result = await _usuarioService.SetUsuarioAsync(request.Transaccion, xml);

                if (!result.Success)
                {
                    return BadRequest(new
                    {
                        Success = false,
                        Message = result.Mensaje,
                        errorCode = result.Error
                    });
                }

                return Ok(new ApiResponse<Usuario>
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
