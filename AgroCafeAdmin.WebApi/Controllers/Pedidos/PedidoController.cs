using AgroCafeAdmin.Common.Request;
using AgroCafeAdmin.Core.Generic;
using AgroCafeAdmin.Core.Models.Pedidos;
using AgroCafeAdmin.Data.Utils;
using AgroCafeAdmin.Service.Pedidos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace AgroCafeAdmin.WebApi.Controllers.Pedidos
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class PedidoController : Controller
    {
        private readonly IPedidoService _service;
        public PedidoController(IPedidoService service) { _service = service; }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> GetPedidosTransaccion([FromBody] PedidoRequest request)
        {
            XDocument xml = XmlSerializerHelper.GetXml(request);
            var result = await _service.GetPedidoAsync(request.Transaccion, xml);
            if (!result.Success) return BadRequest(new { Success = false, Message = result.Mensaje });
            return Ok(new ApiResponse<List<Pedido>> { Data = result.Data, Message = result.Mensaje });
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> SetPedidoTransaccion([FromBody] PedidoRequest request)
        {
            // El XmlSerializerHelper debe ser capaz de serializar la lista de Items.
            // Asegúrate de que tu helper use XmlSerializer estándar o construya el XML recursivamente.
            XDocument xml = XmlSerializerHelper.GetXml(request);

            var result = await _service.SetPedidoAsync(request.Transaccion, xml);
            if (!result.Success) return BadRequest(new { Success = false, Message = result.Mensaje });

            return Ok(new ApiResponse<Pedido> { Data = result.Data, Message = result.Mensaje });
        }
    }
}
