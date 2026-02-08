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
    public class FincaController : Controller
    {
        private readonly IFincaService _service;
        public FincaController(IFincaService service) { _service = service; }

        /// <summary>
        /// Metodo para obtener el listado de fincas registradas ["TRX_GET_ALL_FINCAS", "TRX_GET_FINCA_ID"]
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> GetFincasTransaccion([FromBody] FincaRequest request)
        {
            XDocument xml = XmlSerializerHelper.GetXml(request);
            var result = await _service.GetFincasAsync(request.Transaccion, xml);
            if (!result.Success) return BadRequest(new { Success = false, Message = result.Mensaje });
            return Ok(new ApiResponse<List<Finca>> { Data = result.Data, Message = result.Mensaje });
        }

        /// <summary>
        /// Metodo para crear, actualizar o eliminar una finca ["TRX_INSERT_FINCA", "TRX_UPDATE_FINCA", "TRX_DELETE_FINCA"]
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> SetFincaTransaccion([FromBody] FincaRequest request)
        {
            XDocument xml = XmlSerializerHelper.GetXml(request);
            var result = await _service.SetFincaAsync(request.Transaccion, xml);
            if (!result.Success) return BadRequest(new { Success = false, Message = result.Mensaje });
            return Ok(new ApiResponse<Finca> { Data = result.Data, Message = result.Mensaje });
        }
    }
}
