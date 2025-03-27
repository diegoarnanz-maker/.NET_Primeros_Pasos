using TiendaApi.Models;

namespace TiendaApi.Repositories
{
    public interface IProductoRepository
    {
        Task<List<Producto>> GetAllAsync();
        Task<Producto?> GetByIdAsync(int id);
        Task<Producto> CreateAsync(Producto producto);
        Task<Producto> UpdateAsync(Producto producto);
        Task DeleteAsync(int id);
        Task<int> CountAsync();
        Task<List<Producto>> GetPagedAsync(int page, int pageSize);
    }
}
