using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TallerUG.Common;

namespace AgroCafeAdmin.Common.Request
{
    public class PedidoRequest : BaseRequest
    {
        public int? Id { get; set; }
        public int? ClienteId { get; set; }
        public DateTime? Fecha { get; set; }
        public string? NumeroFactura { get; set; }
        public decimal? Total { get; set; }
        public string? Estado { get; set; }
        public string? Observaciones { get; set; }

        // Lista de detalles
        public List<DetalleRequest> Items { get; set; } = new List<DetalleRequest>();
    }
}
