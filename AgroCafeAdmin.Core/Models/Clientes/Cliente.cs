using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroCafeAdmin.Core.Models.Clientes
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Ruc { get; set; } = string.Empty;

        [Required]
        [MaxLength(150)]
        public string RazonSocial { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string Email { get; set; } = string.Empty;

        [Required]
        [MaxLength(20)]
        public string Telefono { get; set; } = string.Empty;

        [Required]
        [MaxLength(20)]
        public string Tipo { get; set; } = string.Empty; // 'Nacional' | 'Extranjero'

        public bool Anulado { get; set; } = false;
    }
}
