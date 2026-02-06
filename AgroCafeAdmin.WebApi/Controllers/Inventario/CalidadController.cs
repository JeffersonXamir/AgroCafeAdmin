using AgroCafeAdmin.Common.Request;
using AgroCafeAdmin.Core.Generic;
using AgroCafeAdmin.Core.Models.Bitacoras;
using AgroCafeAdmin.Core.Models.Inventario;
using AgroCafeAdmin.Data.Utils;
using AgroCafeAdmin.Service.Bitacoras;
using AgroCafeAdmin.Service.Inventario;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace AgroCafeAdmin.WebApi.Controllers.Inventario
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class CalidadController : Controller
    {
        private readonly ICalidadService _service;
        public CalidadController(ICalidadService service) { _service = service; }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> GetCalidadTransaccion([FromBody] CalidadRequest request)
        {
            XDocument xml = XmlSerializerHelper.GetXml(request);
            var result = await _service.GetCalidadAsync(request.Transaccion, xml);
            if (!result.Success) return BadRequest(new { Success = false, Message = result.Mensaje });
            return Ok(new ApiResponse<List<Calidad>> { Data = result.Data, Message = result.Mensaje });
        }
    }
}
