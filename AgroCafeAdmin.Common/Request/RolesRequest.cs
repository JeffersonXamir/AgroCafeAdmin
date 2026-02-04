using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TallerUG.Common;

namespace AgroCafeAdmin.Common.Request
{
    public class RolesRequest : BaseRequest
    {
        public int? Id { get; set; }
        public string? Codigo { get; set; }
        public string? Nombre { get; set; }
        public bool? Anulado { get; set; }
    }
}
