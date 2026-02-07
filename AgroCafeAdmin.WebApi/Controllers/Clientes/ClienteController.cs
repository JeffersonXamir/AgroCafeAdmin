using AgroCafeAdmin.Common.Request;
using AgroCafeAdmin.Core.Generic;
using AgroCafeAdmin.Core.Models.Clientes;
using AgroCafeAdmin.Data.Utils;
using AgroCafeAdmin.Service.Clientes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace AgroCafeAdmin.WebApi.Controllers.Clientes
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ClienteController : Controller
    {
        private readonly IClienteService _service;
        public ClienteController(IClienteService service) { _service = service; }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> GetClientesTransaccion([FromBody] ClienteRequest request)
        {
            XDocument xml = XmlSerializerHelper.GetXml(request);
            var result = await _service.GetClientesAsync(request.Transaccion, xml);

            if (!result.Success) return BadRequest(new { Success = false, Message = result.Mensaje });
            return Ok(new ApiResponse<List<Cliente>> { Data = result.Data, Message = result.Mensaje });
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> SetClienteTransaccion([FromBody] ClienteRequest request)
        {
            XDocument xml = XmlSerializerHelper.GetXml(request);
            var result = await _service.SetClienteAsync(request.Transaccion, xml);

            if (!result.Success) return BadRequest(new { Success = false, Message = result.Mensaje });
            return Ok(new ApiResponse<Cliente> { Data = result.Data, Message = result.Mensaje });
        }
    }
}
