using TiendaApi.Dtos;
using TiendaApi.Models;
using TiendaApi.Repositories;

namespace TiendaApi.Services
{
    public class ProductoServiceImplMSSql : IProductoService
    {
        private readonly IProductoRepository _productoRepository;

        public ProductoServiceImplMSSql(IProductoRepository productoRepository)
        {
            _productoRepository = productoRepository;
        }


        public async Task<Producto> CreateAsync(Producto producto)
        {
            return await _productoRepository.CreateAsync(producto);
        }

        public async Task DeleteAsync(int id)
        {
            await _productoRepository.DeleteAsync(id);
        }

        public async Task<List<Producto>> GetAllAsync()
        {
            return await _productoRepository.GetAllAsync();
        }

        public Task<Producto?> GetByIdAsync(int id)
        {
            return _productoRepository.GetByIdAsync(id);
        }

        public Task<Producto> UpdateAsync(int id, Producto producto)
        {
            producto.Id = id;
            return _productoRepository.UpdateAsync(producto);
        }
        public async Task<PagedResponse<Producto>> GetPagedAsync(int page, int pageSize)
        {
            var totalItems = await _productoRepository.CountAsync();
            var productos = await _productoRepository.GetPagedAsync(page, pageSize);

            return new PagedResponse<Producto>(
                "Productos paginados correctamente",
                productos,
                totalItems,
                page,
                pageSize
            );
        }
    }
}