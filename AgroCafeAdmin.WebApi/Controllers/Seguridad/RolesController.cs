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
    public class RolesController : Controller
    {
        private readonly IRolesService _usuarioService;

        public RolesController(IRolesService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        /// <summary>
        /// Metodo para obtener el listado de roles del sistema ["TRX_GET_ALL_ROLES"]
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> GetRolesTransaccion([FromBody] RolesRequest request)
        {
            try
            {
                XDocument xml = XmlSerializerHelper.GetXml(request);
                var xmlString = XmlSerializerHelper.SerializeToXml(request);

                var result = await _usuarioService.GetRolesAsync(request.Transaccion, xml);

                if (!result.Success)
                {
                    return BadRequest(new
                    {
                        Success = false,
                        Message = result.Mensaje,
                        errorCode = result.Error
                    });
                }

                return Ok(new ApiResponse<List<Roles>>
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
        /// Metodo para crear o modificar roles de usuario ["TRX_INSERT_ROL", "TRX_UPDATE_ROL"]
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> SetRolesTransaccion([FromBody] RolesRequest request)
        {
            try
            {
                XDocument xml = XmlSerializerHelper.GetXml(request);
                var xmlString = XmlSerializerHelper.SerializeToXml(request);

                var result = await _usuarioService.SetRolesAsync(request.Transaccion, xml);

                if (!result.Success)
                {
                    return BadRequest(new
                    {
                        Success = false,
                        Message = result.Mensaje,
                        errorCode = result.Error
                    });
                }

                return Ok(new ApiResponse<Roles>
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

