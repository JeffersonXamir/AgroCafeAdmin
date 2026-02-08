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
    public class ParcelaController : Controller
    {
        private readonly IParcelaService _service;
        public ParcelaController(IParcelaService service) { _service = service; }

        /// <summary>
        /// Metodo para obtener las parcelas asociadas a las fincas ["TRX_GET_ALL_PARCELAS"]
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> GetParcelasTransaccion([FromBody] ParcelaRequest request)
        {
            XDocument xml = XmlSerializerHelper.GetXml(request);
            var result = await _service.GetParcelasAsync(request.Transaccion, xml);
            if (!result.Success) return BadRequest(new { Success = false, Message = result.Mensaje });
            return Ok(new ApiResponse<List<Parcela>> { Data = result.Data, Message = result.Mensaje });
        }

        /// <summary>
        /// Metodo para administrar las parcelas (Crear, Editar, Borrar) ["TRX_INSERT_PARCELA", "TRX_UPDATE_PARCELA", "TRX_DELETE_PARCELA"]
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> SetParcelaTransaccion([FromBody] ParcelaRequest request)
        {
            XDocument xml = XmlSerializerHelper.GetXml(request);
            var result = await _service.SetParcelaAsync(request.Transaccion, xml);
            if (!result.Success) return BadRequest(new { Success = false, Message = result.Mensaje });
            return Ok(new ApiResponse<Parcela> { Data = result.Data, Message = result.Mensaje });
        }
    }
}
