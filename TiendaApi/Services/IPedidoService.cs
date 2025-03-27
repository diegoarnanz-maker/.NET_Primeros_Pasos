using TiendaApi.Dtos;
using TiendaApi.Models;

namespace TiendaApi.Services
{
    public interface IPedidoService
    {
        Task<List<Pedido>> GetAllAsync();
        Task<Pedido?> GetByIdAsync(int id);
        Task<Pedido> CreateAsync(Pedido pedido, List<LineaPedidoRequestDto> lineas);
        Task<Pedido> UpdateAsync(int id, Pedido pedido);
        Task DeleteAsync(int id);
    }
}
