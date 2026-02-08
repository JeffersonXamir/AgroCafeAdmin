using AgroCafeAdmin.Core.Models.Clientes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroCafeAdmin.Core.Models.Pedidos
{
    public class Pedido
    {
        [Key] public int Id { get; set; }

        public int ClienteId { get; set; }
        [ForeignKey("ClienteId")] public virtual Cliente? Cliente { get; set; }

        public DateTime Fecha { get; set; }

        [Required, MaxLength(20)] public string NumeroFactura { get; set; } = string.Empty;

        [Column(TypeName = "decimal(12,2)")] public decimal Total { get; set; }

        [Required, MaxLength(20)] public string Estado { get; set; } = "PAGADO"; // PAGADO, ANULADO

        [MaxLength(500)] public string? Observaciones { get; set; }

        // Relación 1 a muchos
        public virtual List<DetallePedido> Items { get; set; } = new List<DetallePedido>();
    }
}
