namespace TiendaApi.Dtos
{
    public class PedidoResponseDto
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }
        public List<LineaPedidoResponseDto> Lineas { get; set; } = new();

    }
}
