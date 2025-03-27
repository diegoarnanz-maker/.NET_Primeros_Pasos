using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TiendaApi.Models // 🔹 Como el package en Java
{
    // 🔸 Equivalente a: @Entity en Spring Boot
    public class Producto
    {
        // 🔸 [Key] equivale a @Id
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        // 🔸 @GeneratedValue(strategy = GenerationType.IDENTITY). Aunque .NET ya asume que lo es al ser int o long
        public int Id { get; set; }

        // 🔸 [Required] = @NotNull / @NotEmpty
        [Required]
        [StringLength(100)] // 🔸 Limita longitud como @Column(length=100)
        public string Nombre { get; set; } = string.Empty;

        // 🔸 [Column(TypeName = "decimal(10,2)")] es como @Column(precision = 10, scale = 2)
        [Column(TypeName = "decimal(10,2)")]
        [Range(0.01, 10000)] // Opcional: valida el rango
        public decimal Precio { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int Stock { get; set; }
    }
}
