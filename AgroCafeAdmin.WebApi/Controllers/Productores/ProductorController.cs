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
    public class ProductorController : Controller
    {
        private readonly IProductorService _service;
        public ProductorController(IProductorService service) { _service = service; }

        /// <summary>
        /// Metodo para obtener el directorio de productores ["TRX_GET_ALL_PRODUCTORES", "TRX_GET_PRODUCTOR_ID"]
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> GetProductoresTransaccion([FromBody] ProductorRequest request)
        {
            // ... (Misma lógica de serialización XML que UsuarioController)
            XDocument xml = XmlSerializerHelper.GetXml(request);
            var result = await _service.GetProductoresAsync(request.Transaccion, xml);

            if (!result.Success) return BadRequest(new { Success = false, Message = result.Mensaje });
            return Ok(new ApiResponse<List<Productor>> { Data = result.Data, Message = result.Mensaje });
        }

        /// <summary>
        /// Metodo para gestionar la informacion de los productores ["TRX_INSERT_PRODUCTOR", "TRX_UPDATE_PRODUCTOR", "TRX_DELETE_PRODUCTOR"]
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> SetProductorTransaccion([FromBody] ProductorRequest request)
        {
            // ... (Misma lógica serialización)
            XDocument xml = XmlSerializerHelper.GetXml(request);
            var result = await _service.SetProductorAsync(request.Transaccion, xml);

            if (!result.Success) return BadRequest(new { Success = false, Message = result.Mensaje });
            return Ok(new ApiResponse<Productor> { Data = result.Data, Message = result.Mensaje });
        }
    }
}
