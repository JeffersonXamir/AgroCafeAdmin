using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroCafeAdmin.Core.Models.Inventario
{
    public class Calidad
    {
        [Key] public int Id { get; set; }
        [Required, MaxLength(50)] public string Nombre { get; set; } = string.Empty; // Primera, Segunda...
        public bool Anulado { get; set; } = false;
    }
}
