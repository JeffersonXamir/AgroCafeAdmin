using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TallerUG.Common;

namespace AgroCafeAdmin.Common.Request
{
    public class LaborRequest : BaseRequest
    {
        // Solo necesitamos transaccion para listar, pero dejamos la estructura lista
        public int? Id { get; set; }
    }
}
