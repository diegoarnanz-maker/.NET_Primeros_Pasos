using TiendaApi.Models;

namespace TiendaApi.Repositories
{
    // public interface PedidoRepository extends JpaRepository<Pedido, Integer> {}
    public interface IPedidoRepository
    {
        Task<List<Pedido>> GetAllAsync();
        Task<Pedido?> GetByIdAsync(int id);
        Task<Pedido> CreateAsync(Pedido pedido);
        Task<Pedido> UpdateAsync(Pedido pedido);
        Task DeleteAsync(int id);
    }
}