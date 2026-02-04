using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TallerUG.Common;

namespace AgroCafeAdmin.Common.Request
{
    public class FincaRequest : BaseRequest
    {
        public int? Id { get; set; }
        public string? Nombre { get; set; }
        public string? Ubicacion { get; set; }
        public decimal? Hectareas { get; set; }
        public int? ProductorId { get; set; }
        public bool? Anulado { get; set; }
    }
}
