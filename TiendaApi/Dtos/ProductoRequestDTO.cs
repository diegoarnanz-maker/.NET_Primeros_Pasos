using System.ComponentModel.DataAnnotations;

namespace TiendaApi.Dtos
{
    public class ProductoRequestDto
{
    [Required]
    [StringLength(100)]
    public string Nombre { get; set; } = string.Empty;

    [Range(0.01, 10000)]
    public decimal Precio { get; set; }

    [Range(0, int.MaxValue)]
    public int Stock { get; set; }
}

}
