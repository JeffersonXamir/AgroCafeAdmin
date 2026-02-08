using AgroCafeAdmin.Common.Request;
using AgroCafeAdmin.Core.Generic;
using AgroCafeAdmin.Core.Models.Bitacoras;
using AgroCafeAdmin.Data.Utils;
using AgroCafeAdmin.Service.Bitacoras;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace AgroCafeAdmin.WebApi.Controllers.Labors
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class LaborController : Controller
    {
        private readonly ILaborService _service;
        public LaborController(ILaborService service) { _service = service; }

        /// <summary>
        /// Metodo para obtener el catalogo de labores disponibles ["TRX_GET_ALL_LABORES"]
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> GetLaborTransaccion([FromBody] LaborRequest request)
        {
            XDocument xml = XmlSerializerHelper.GetXml(request);
            var result = await _service.GetLaborAsync(request.Transaccion, xml);
            if (!result.Success) return BadRequest(new { Success = false, Message = result.Mensaje });
            return Ok(new ApiResponse<List<Labor>> { Data = result.Data, Message = result.Mensaje });
        }
    }
}
