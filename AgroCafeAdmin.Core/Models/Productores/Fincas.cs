using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroCafeAdmin.Core.Models.Productores
{
    public class Finca
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(150)]
        public string Nombre { get; set; } = string.Empty;

        [Required]
        [MaxLength(250)]
        public string Ubicacion { get; set; } = string.Empty;

        [Column(TypeName = "decimal(10,2)")]
        public decimal Hectareas { get; set; }

        // Relación con Productor
        public int ProductorId { get; set; }

        [ForeignKey("ProductorId")]
        public virtual Productor? Productor { get; set; }

        public bool Anulado { get; set; } = false; // Mapea a 'Activa' en el frontend (inverso)
    }
}
