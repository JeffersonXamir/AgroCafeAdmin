using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TallerUG.Common;

namespace AgroCafeAdmin.Common.Request
{
    public class ClienteRequest : BaseRequest
    {
        public int? Id { get; set; }
        public string? Ruc { get; set; }
        public string? RazonSocial { get; set; }
        public string? Email { get; set; }
        public string? Telefono { get; set; }
        public string? Tipo { get; set; }
        public bool? Anulado { get; set; }
    }
}
