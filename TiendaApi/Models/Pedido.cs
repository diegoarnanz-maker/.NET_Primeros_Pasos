using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TiendaApi.Models
{
    // 🔸 Equivalente a: @Entity en Spring Boot
    public class Pedido
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // 🔸 Como @GeneratedValue(strategy = IDENTITY)
        public int Id { get; set; }

        // 🔹 Fecha del pedido: se inicializa por defecto en el constructor o en la base de datos
        public DateTime Fecha { get; set; } = DateTime.Now;

        // 🔹 Total del pedido: decimal(10,2)
        [Column(TypeName = "decimal(10,2)")]
        public decimal Total { get; set; }

        // 🔹 Relación 1:N con LineasPedido (como @OneToMany(mappedBy="pedido"))
        // En EF Core no se ponen anotaciones sino que funciona por convención o se puede configurar Fluent API dentro de AppDbContext.cs asi:
            // modelBuilder.Entity<LineaPedido>()
            // .HasOne(lp => lp.Pedido)
            // .WithMany(p => p.Lineas)
            // .HasForeignKey(lp => lp.IdPedido);
        // o marcarlo en la propia entidad LineaPedido con [ForeignKey("IdPedido")]

        public List<LineaPedido> Lineas { get; set; } = new List<LineaPedido>();
    }
}
