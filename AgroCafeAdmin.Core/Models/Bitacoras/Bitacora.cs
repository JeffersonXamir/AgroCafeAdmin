using AgroCafeAdmin.Core.Models.Productores;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroCafeAdmin.Core.Models.Bitacoras
{
    public class Bitacora
    {
        [Key]
        public int Id { get; set; }

        public int ParcelaId { get; set; }
        [ForeignKey("ParcelaId")]
        public virtual Parcela? Parcela { get; set; }

        public DateTime Fecha { get; set; }

        [Required, MaxLength(20)]
        public string Tipo { get; set; } = string.Empty; // 'LABOR' o 'PLAGA'

        [Required, MaxLength(100)]
        public string NombreEvento { get; set; } = string.Empty; // Guardamos el nombre (snapshot)

        [MaxLength(20)]
        public string? Severidad { get; set; } // 'BAJA', 'MEDIA', 'ALTA' (Solo si es plaga)

        [MaxLength(500)]
        public string? Notas { get; set; }
    }
}
