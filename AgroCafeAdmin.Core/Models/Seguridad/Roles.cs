using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroCafeAdmin.Core.Models.Seguridad
{
    public class Roles
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public bool Anulado{ get; set; }
    }
}
