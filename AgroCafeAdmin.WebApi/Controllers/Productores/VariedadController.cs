using AgroCafeAdmin.Common.Request;
using AgroCafeAdmin.Core.Generic;
using AgroCafeAdmin.Core.Models.Productores;
using AgroCafeAdmin.Data.Utils;
using AgroCafeAdmin.Service.Productores;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace AgroCafeAdmin.WebApi.Controllers.Productores
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class VariedadController : Controller
    {
        private readonly IVariedadService _service;
        public VariedadController(IVariedadService service) { _service = service; }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> GetVariedadesTransaccion([FromBody] VariedadRequest request)
        {
            XDocument xml = XmlSerializerHelper.GetXml(request);
            var result = await _service.GetVariedadesAsync(request.Transaccion, xml);
            if (!result.Success) return BadRequest(new { Success = false, Message = result.Mensaje });
            return Ok(new ApiResponse<List<Variedad>> { Data = result.Data, Message = result.Mensaje });
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> SetVariedadTransaccion([FromBody] VariedadRequest request)
        {
            XDocument xml = XmlSerializerHelper.GetXml(request);
            var result = await _service.SetVariedadAsync(request.Transaccion, xml);
            if (!result.Success) return BadRequest(new { Success = false, Message = result.Mensaje });
            return Ok(new ApiResponse<Variedad> { Data = result.Data, Message = result.Mensaje });
        }
    }
}
