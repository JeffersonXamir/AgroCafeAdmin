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

        /// <summary>
        /// Metodo para obtener el catalogo de variedades de cafe ["TRX_GET_ALL_VARIEDADES"]
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> GetVariedadesTransaccion([FromBody] VariedadRequest request)
        {
            XDocument xml = XmlSerializerHelper.GetXml(request);
            var result = await _service.GetVariedadesAsync(request.Transaccion, xml);
            if (!result.Success) return BadRequest(new { Success = false, Message = result.Mensaje });
            return Ok(new ApiResponse<List<Variedad>> { Data = result.Data, Message = result.Mensaje });
        }

        /// <summary>
        /// Metodo para administrar las variedades de cafe ["TRX_INSERT_VARIEDAD", "TRX_UPDATE_VARIEDAD", "TRX_DELETE_VARIEDAD"]
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
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
