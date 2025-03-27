using TiendaApi.Dtos;
using TiendaApi.Models;

namespace TiendaApi.Services
{
    // 🔸 Equivalente a: public interface ProductoService { ... }
    public interface IProductoService
    {
        Task<List<Producto>> GetAllAsync();            // findAll()
        Task<Producto?> GetByIdAsync(int id);          // findById(id)
        Task<Producto> CreateAsync(Producto producto); // save(producto)
        Task<Producto> UpdateAsync(int id, Producto producto); // update(producto)
        Task DeleteAsync(int id);                      // deleteById(id)
        Task<PagedResponse<Producto>> GetPagedAsync(int page, int pageSize);

    }
}
