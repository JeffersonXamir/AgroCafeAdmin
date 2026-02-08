using AgroCafeAdmin.Common.Request;
using AgroCafeAdmin.Core.Generic;
using AgroCafeAdmin.Core.Models.Bitacoras;
using AgroCafeAdmin.Data.Utils;
using AgroCafeAdmin.Service.Bitacoras;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace AgroCafeAdmin.WebApi.Controllers.Bitacoras
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class PlagaController : Controller
    {
        private readonly IPlagasService _service;
        public PlagaController(IPlagasService service) { _service = service; }

        /// <summary>
        /// Metodo para obtener el catalogo de plagas registradas ["TRX_GET_ALL_PLAGAS"]
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> GetPlagasTransaccion([FromBody] PlagaRequest request)
        {
            XDocument xml = XmlSerializerHelper.GetXml(request);
            var result = await _service.GetPlagasAsync(request.Transaccion, xml);
            if (!result.Success) return BadRequest(new { Success = false, Message = result.Mensaje });
            return Ok(new ApiResponse<List<Plaga>> { Data = result.Data, Message = result.Mensaje });
        }
    }
}
