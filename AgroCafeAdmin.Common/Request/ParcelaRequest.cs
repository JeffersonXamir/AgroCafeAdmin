using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TallerUG.Common;

namespace AgroCafeAdmin.Common.Request
{
    public class ParcelaRequest : BaseRequest
    {
        public int? Id { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public decimal? Area { get; set; }
        public int? FincaId { get; set; }
        public int? VariedadId { get; set; } // ID de la variedad seleccionada
        public bool? Anulado { get; set; }
    }
}
