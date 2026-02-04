using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroCafeAdmin.Core.Models.Productores
{
    public class Productor
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(13)]
        public string Cedula { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string Nombre { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string Apellido { get; set; } = string.Empty;

        [MaxLength(100)]
        public string? Email { get; set; }

        [MaxLength(20)]
        public string Telefono { get; set; } = string.Empty;

        [MaxLength(250)]
        public string Direccion { get; set; } = string.Empty;

        public bool Anulado { get; set; } = false;
    }
}
