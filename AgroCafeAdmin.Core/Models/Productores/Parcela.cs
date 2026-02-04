using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroCafeAdmin.Core.Models.Productores
{
    public class Parcela
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(150)]
        public string Nombre { get; set; } = string.Empty; // Ej: Sector Norte

        [MaxLength(500)]
        public string? Descripcion { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal Area { get; set; }

        // Relación con Finca
        public int FincaId { get; set; }
        [ForeignKey("FincaId")]
        public virtual Finca? Finca { get; set; }

        // Relación con Variedad (Usamos ID en lugar de string libre)
        public int VariedadId { get; set; }
        [ForeignKey("VariedadId")]
        public virtual Variedad? Variedad { get; set; }

        public bool Anulado { get; set; } = false;
    }
}
