using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroCafeAdmin.Core.Models.Inventario
{
    public class Lote
    {
        [Key] public int Id { get; set; }

        [Required, MaxLength(20)] public string Codigo { get; set; } = string.Empty; // Generado L-2025-001

        public int ParcelaId { get; set; } // Origen

        public DateTime FechaCosecha { get; set; }

        [Column(TypeName = "decimal(12,2)")] public decimal CantidadInicial { get; set; }

        [Column(TypeName = "decimal(12,2)")] public decimal StockActual { get; set; }

        public int UnidadId { get; set; }
        [ForeignKey("UnidadId")] public virtual Unidad? Unidad { get; set; }

        public int CalidadId { get; set; }
        [ForeignKey("CalidadId")] public virtual Calidad? Calidad { get; set; }

        [Required, MaxLength(20)] public string Estado { get; set; } = "DISPONIBLE"; // DISPONIBLE, AGOTADO

        [MaxLength(500)] public string? Notas { get; set; }
        public bool Anulado { get; set; } = false;
    }
}
