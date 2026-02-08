using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TallerUG.Common;

namespace AgroCafeAdmin.Common.Request
{
    public class MovimientoRequest : BaseRequest
    {
        public int? Id { get; set; }
        public int? LoteId { get; set; }
        public DateTime? Fecha { get; set; } = DateTime.Now;
        public string? Tipo { get; set; } = string.Empty;
        public decimal? Cantidad { get; set; }
        public bool? EsEntrada { get; set; }
        public string? Motivo { get; set; } = string.Empty;
    }
}
