using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroCafeAdmin.Core.Models.Inventario
{
    public class Movimiento
    {
        [Key] public int Id { get; set; }

        public int LoteId { get; set; }
        [ForeignKey("LoteId")] public virtual Lote? Lote { get; set; }

        public DateTime Fecha { get; set; } = DateTime.Now;

        [Required, MaxLength(20)] public string Tipo { get; set; } = string.Empty; // COSECHA, VENTA

        [Column(TypeName = "decimal(12,2)")] public decimal Cantidad { get; set; }

        public bool EsEntrada { get; set; } // true = suma, false = resta

        [MaxLength(250)] public string Motivo { get; set; } = string.Empty;
    }
}
