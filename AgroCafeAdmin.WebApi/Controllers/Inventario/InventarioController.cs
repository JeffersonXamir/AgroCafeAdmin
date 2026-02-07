using AgroCafeAdmin.Common.Request;
using AgroCafeAdmin.Core.Generic;
using AgroCafeAdmin.Core.Models.Inventario;
using AgroCafeAdmin.Data.Utils;
using AgroCafeAdmin.Service.Inventario;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;
using TallerUG.Common;

namespace AgroCafeAdmin.WebApi.Controllers.Inventario
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class InventarioController : Controller
    {
        private readonly IInventarioService _service;
        public InventarioController(IInventarioService service) { _service = service; }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> GetLotesTransaccion([FromBody] LoteRequest request)
        {
            XDocument xml = XmlSerializerHelper.GetXml(request);
            var result = await _service.GetLoteAsync(request.Transaccion, xml);
            if (!result.Success) return BadRequest(new { Success = false, Message = result.Mensaje });
            return Ok(new ApiResponse<List<Lote>> { Data = result.Data, Message = result.Mensaje });
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> SetLoteTransaccion([FromBody] LoteRequest request)
        {
            XDocument xml = XmlSerializerHelper.GetXml(request);
            var result = await _service.SetLoteAsync(request.Transaccion, xml);
            if (!result.Success) return BadRequest(new { Success = false, Message = result.Mensaje });
            return Ok(new ApiResponse<Lote> { Data = result.Data, Message = result.Mensaje });
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> GetMovimientosTransaccion([FromBody] BaseRequest request)
        {
            try
            {
                // Serializamos el request (aunque vaya vacío o solo con transacción)
                XDocument xml = XmlSerializerHelper.GetXml(request);

                var result = await _service.GetMovimientosAsync(request.Transaccion, xml);

                if (!result.Success)
                {
                    return BadRequest(new ApiResponse<object> { Success = false, Message = result.Mensaje });
                }

                return Ok(new ApiResponse<List<Movimiento>>
                {
                    Success = true,
                    Message = result.Mensaje,
                    Data = result.Data
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse<object> { Message = ex.Message });
            }
        }
    }
}
