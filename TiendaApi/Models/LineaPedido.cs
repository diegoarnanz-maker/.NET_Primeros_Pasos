using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TiendaApi.Models
{
    // 🔸 Esta clase representa una línea de un pedido (producto + cantidad + precio)
    public class LineaPedido
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        // 🔹 Cantidad de productos comprados
        [Required]
        public int Cantidad { get; set; }

        // 🔹 Precio por unidad en el momento del pedido
        [Column(TypeName = "decimal(10,2)")]
        [Required]
        public decimal PrecioUnitario { get; set; }

        // 🔹 Clave foránea hacia Pedido
        [ForeignKey("Pedido")]
        public int IdPedido { get; set; }

        // 🔹 Relación muchos a uno (N:1) con Pedido
        public Pedido Pedido { get; set; } = null!;

        // 🔹 Clave foránea hacia Producto
        [ForeignKey("Producto")]
        public int IdProducto { get; set; }

        // 🔹 Relación muchos a uno (N:1) con Producto
        public Producto Producto { get; set; } = null!;
    }
}
