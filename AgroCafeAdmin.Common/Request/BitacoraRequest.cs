using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TallerUG.Common;

namespace AgroCafeAdmin.Common.Request
{
    public class BitacoraRequest : BaseRequest
    {
        public int? Id { get; set; }
        public int? ParcelaId { get; set; }
        public DateTime? Fecha { get; set; }
        public string? Tipo { get; set; }
        public string? NombreEvento { get; set; }
        public string? Severidad { get; set; }
        public string? Notas { get; set; }
    }
}
