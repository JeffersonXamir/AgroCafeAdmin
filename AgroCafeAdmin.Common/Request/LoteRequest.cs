using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TallerUG.Common;

namespace AgroCafeAdmin.Common.Request
{
    public class LoteRequest : BaseRequest
    {
        public int? Id { get; set; }
        public int? ParcelaId { get; set; }
        public DateTime? FechaCosecha { get; set; }
        public decimal? CantidadInicial { get; set; }
        public int? UnidadId { get; set; }
        public int? CalidadId { get; set; }
        public string? Notas { get; set; }
        // Para movimientos, opcionalmente podrías reutilizar o crear MovimientoRequest
    }
}
