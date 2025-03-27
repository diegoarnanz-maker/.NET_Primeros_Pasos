namespace TiendaApi.Dtos
{
    public class PedidoRequestDto
    {
        public List<LineaPedidoRequestDto> Lineas { get; set; } = new List<LineaPedidoRequestDto>();
    }
}
