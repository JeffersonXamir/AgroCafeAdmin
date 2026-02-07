using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroCafeAdmin.Core.Models.Pedidos
{
    public class DetallePedido
    {
        [Key] public int Id { get; set; }

        public int PedidoId { get; set; }
        [ForeignKey("PedidoId")] public virtual Pedido? Pedido { get; set; }

        public int LoteId { get; set; } // El producto que vendemos

        [Column(TypeName = "decimal(12,2)")] public decimal Cantidad { get; set; }
        [Column(TypeName = "decimal(12,2)")] public decimal PrecioUnitario { get; set; }
        [Column(TypeName = "decimal(12,2)")] public decimal Subtotal { get; set; }
    }
}
